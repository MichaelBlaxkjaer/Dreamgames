/**
 * A video.
 * 
 * @typedef {Object} Video
 * @property {number} id
 * @property {number} order
 * @property {string} path
 * @property {string} ambiencePath
 * @property {number|null} videoSequenceId
 */

/**
 * A video sequence.
 * 
 * @typedef {Object} VideoSequence
 * @property {number} id
 * @property {Video[]} videos
 */

/**
 * A question.
 * 
 * @typedef {Object} Question
 * @property {number} id
 * @property {string} description
 * @property {string} motivePath
 * @property {number} ordering
 * @property {number|null} introVideoId
 * @property {VideoSequence} introVideo
 * @property {Answer[]} answers
 */

/**
 * An answer to a question. Potentially with a follow up question.
 * 
 * @typedef {Object} Answer
 * @property {number} id
 * @property {string} text
 * @property {string} imagePath
 * @property {number} answerOrder
 * @property {number|null} outroVideoId
 * @property {VideoSequence} outroVideo
 * @property {number} questionId
 * @property {number|null} followUpQuestionId
 * @property {Question} followUpQuestion
 */

 
/**
 * A game.
 * 
 * @typedef {Object} Game
 * @property {number} id
 * @property {number} gameId
 * @property {string} title
 * @property {string} slug
 * @property {string} backgroundImage
 * @property {number} avgRating
 * @property {string} trailer
 */

class DreamApi {
    constructor(baseUrl) {
        this.baseUrl = baseUrl;
    }

    /**
     * Gets the questions to ask from the server.
     *
     * @returns {Promise<Question[]>}
     * @memberof DreamApi
     */
    async getQuestions() {
        const response = await fetch(`${this.baseUrl}/question`);
        return await response.json();
    }

    /**
     * Posts the answers to the server and receives back a game.
     *
     * @param {number[]} answers
     * @returns {Promise<Game>}
     * @memberof DreamApi
     */
    async getResult(answers) {
        const response = await fetch(`${this.baseUrl}/question/result`, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(answers)
        });
        return await response.json();
    }
}

class App {

    constructor() {
        this.player = document.querySelector('#scenario video');

        this.audio = new Audio();
        this.audio.loop = true;

        this.api = new DreamApi('api');

        this.api.getQuestions().then(questions => this.questions = questions);

        const answerContainer = document.getElementById('answers');
        answerContainer.addEventListener('click', e => {
            if (this.player.playing || e.target === answerContainer)
                return;

            const button = e.target.closest('button');
            const answerId = parseInt(button.getAttribute('answer-id'));
            this.onAnswerClicked(answerId);
        });

        document.addEventListener('keypress', e => {
            if (e.keyCode === 32) {
                if (!this.player.ended && this.player.duration !== NaN)
                    this.player.currentTime = this.player.duration;
            }
        });
    }

    /**
     * @type {Question}
     */
    get question() {
        return this.getQuestionByPath(this.currentQuestionPath);
    }

    /**
     * Changes the question, updating the view accordingly.
     * 
     * @param {number[]} path
     * @memberof App
     */
    set question(path) {
        this.currentQuestionPath = path;

        const question = this.question;

        document.getElementById('question').innerText = question.description || '';

        const answerContainer = document.getElementById('answers');
        answerContainer.innerHTML = question.answers
            .map(a => `<button answer-id="${a.id}">
                         ${a.imagePath ? `<img src="assets/${a.imagePath}" ${a.text ? `alt="${a.text}"` : ''} />` : ''}
                         ${a.text || ''}
                       </button>`)
            .join('');

        this.toggleOverlay(false);

        if (question.introVideo) {
            this.playVideoSequence(question.introVideo)
                .then(() => this.toggleOverlay(true));
        } else {
            this.audio.pause();
            this.toggleOverlay(true);
        }
    }

    /**
     * Toggles the visibility of the video overlay.
     *
     * @param {boolean} show Whether to show or hide the overlay.
     * @memberof App
     */
    toggleOverlay(show) {
        const motive = document.querySelector('.motive');
        const questionContainer = document.querySelector('.question-container');

        motive.classList.toggle('shown', !!this.question.image && show);
        questionContainer.classList.toggle('shown', show);
    }

    /**
     * Starts playing a sequence of videos and returns a promise that resolves when all videos have ended.
     *
     * @param {VideoSequence} sequence
     * @returns {Promise<void>}
     * @memberof App
     */
    async playVideoSequence(sequence) {
        for (const video of sequence.videos)
            await this.playVideoAsync(video);
    }

    /**
     * Starts playing a video and returns a promise that resolves when the video has ended. 
     *
     * @param {Video} video
     * @returns {Promise<void>}
     * @memberof App
     */
    playVideoAsync(video) {
        if (!video.ambiencePath)
            this.audio.pause();
        else if (this.audio.src !== video.ambiencePath)
            this.audio.src = `assets/${video.ambiencePath}`;

        if (video.ambiencePath)
            this.audio.play();

        return new Promise((resolve, reject) => {
            this.player.src = `assets/${video.path}`;
            this.player.onended = resolve;
            this.player.play();
        });
    }

    /**
     * Starts (or restarts) the questionaire.
     *
     * @memberof App
     */
    start() {
        this.answers = [];
        this.question = [0];

        document.getElementById('start').hidden = true;
        document.getElementById('scenario').hidden = false;
        document.getElementById('results').hidden = true;
    }

    /**
     * Called when an answer button is pressed.
     *
     * @param {number} answerId
     * @memberof App
     */
    async onAnswerClicked(answerId) {
        this.toggleOverlay(false);

        this.answers.push(answerId);

        const question = this.question;
        const answerIndex = question.answers.findIndex(a => a.id == answerId);
        const answer = question.answers[answerIndex];

        if (answer.outroVideo)
            await this.playVideoSequence(answer.outroVideo);

        if (answer.followUpQuestion)
            this.question = [...this.currentQuestionPath, answerIndex];
        else
            this.nextBaseQuestion();
    }

    /**
     * Changes to the next base / root question. If this was the last question, then we change to the result screen instead.
     *
     * @memberof App
     */
    nextBaseQuestion() {
        const currentIndex = this.currentQuestionPath[0];

        if (currentIndex + 1 < this.questions.length)
            this.question = [currentIndex + 1];
        else
            this.showResults();
    }

    /**
     * Switches to the result screen
     *
     * @memberof App
     */
    async showResults() {
        document.getElementById('scenario').hidden = true;
        document.getElementById('results').hidden = false;

        const game = await this.api.getResult(this.answers);
        document.getElementById('game-title').innerText = game.title;
        document.getElementById('game-background').setAttribute('src', game.backgroundImage);
        document.getElementById('game-rating').innerText = game.avgRating;
    }

    /**
     * Gets the question at a given path.
     *
     * @param {number[]} path
     * @returns {Question}
     * @memberof App
     */
    getQuestionByPath(path) {
        let node = this.questions[path[0]];

        for (const subindex of path.slice(1))
            node = node.answers[subindex].followUpQuestion;

        return node;
    }
}

const app = new App();
document.getElementById('startbutton').addEventListener('click', () => app.start());