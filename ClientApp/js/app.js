import {
    DreamApi
} from './api.js'

/**
 * A video.
 * 
 * @typedef {Object} Video
 * @property {number} videoId
 * @property {string} path
 * @property {string} ambiencePath
 */

/**
 * A video sequence.
 * 
 * @typedef {Video[]} VideoSequence
 */

/**
 * A question.
 * 
 * @typedef {Object} Question
 * @property {number} id
 * @property {string} description
 * @property {string} type
 * @property {VideoSequence} introVideo
 * @property {string} ambience
 * @property {Answer[]} answers
 */

/**
 * An answer to a question. Potentially with a follow up question.
 * 
 * @typedef {Object} Answer
 * @property {number} id
 * @property {string} text
 * @property {string} image
 * @property {VideoSequence} outroVideo
 * @property {Question|null} followUp
 */

class App {

    /**
     * @type {Question}
     */
    get question() {
        return this.getQuestionByPath(this.currentQuestionPath);
    }

    /**
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
                         ${a.image ? `<img src="assets/${a.image}" ${a.text ? `alt="${a.text}"` : ''} />` : ''}
                         ${a.text || ''}
                       </button>`)
            .join('');

        const questionContainer = document.querySelector('#scenario .question-container');
        questionContainer.classList.remove('shown');

        if (question.introVideo) {
            this.playVideoSequence(question.introVideo)
                .then(() => questionContainer.classList.add('shown'));
        } else {
            questionContainer.classList.add('shown');
        }
    }

    constructor() {
        this.player = document.querySelector('#scenario video');
        this.api = new DreamApi();

        this.api.getQuestions().then(questions => this.questions = questions);

        const answerContainer = document.getElementById('answers');
        answerContainer.addEventListener('click', e => {
            if (!this.player.ended || e.target === answerContainer)
                return;

            const button = e.target.closest('button');
            const answerId = button.getAttribute('answer-id');
            this.onAnswerClicked(answerId);
        });

        document.addEventListener('keypress', e => {
            if (e.keyCode === 32) {
                if (!this.player.ended && this.player.duration !== NaN)
                    this.player.currentTime = this.player.duration;
            }
        });
    }

    async playVideoSequence(sequence) {
        for (const video of sequence)
            await this.playVideoAsync(video);
    }

    playVideoAsync(video) {
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
        document.querySelector('#scenario .question-container').classList.remove('shown');

        this.answers.push(answerId);

        const question = this.question;
        const answerIndex = question.answers.findIndex(a => a.id == answerId);
        const answer = question.answers[answerIndex];

        if (answer.outroVideo)
            await this.playVideoSequence(answer.outroVideo);

        if (answer.followUp)
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

    showResults() {
        document.getElementById('scenario').hidden = true;
        document.getElementById('results').hidden = false;
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
            node = node.answers[subindex].followUp;

        return node;
    }
}

const app = new App();
document.getElementById('startbutton').addEventListener('click', () => app.start());