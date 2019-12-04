/**
 * A video.
 * 
 * @typedef {Object} Video
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
 * @property {Answer[]} answers
 */

/**
 * An answer to a question. Potentially with a follow up question.
 * 
 * @typedef {Object} Answer
 * @property {number} id
 * @property {string} content
 * @property {VideoSequence|null} outroVideo
 * @property {Question|null} followUp
 */

/**
 * @type {Question[]}
 * @const
 */
const questions = [{
        id: 1,
        description: null,
        type: 'scenario',
        introVideo: [{
                path: 'music-intro.webm',
                ambiencePath: null
            },
            {
                path: 'music-streets.webm',
                ambiencePath: 'ambience-streets.mp3'
            }
        ],
        answers: [{
                id: 1,
                content: 'Rock',
                outroVideo: [{
                        path: 'music-enter-shrink.webm',
                        ambiencePath: 'rock.mp3'
                    },
                    {
                        path: 'shrink-intro.webm',
                        ambiencePath: null
                    }
                ],
                followUp: null
            },
            {
                id: 2,
                content: 'Pop',
                outroVideo: [{
                        path: 'music-enter-shrink.webm',
                        ambiencePath: 'pop.mp3'
                    },
                    {
                        path: 'shrink-intro.webm',
                        ambiencePath: null
                    }
                ],
                followUp: null
            },
            {
                id: 3,
                content: 'Jazz',
                outroVideo: [{
                        path: 'music-enter-shrink.webm',
                        ambiencePath: 'jazz.mp3'
                    },
                    {
                        path: 'shrink-intro.webm',
                        ambiencePath: null
                    }
                ],
                followUp: null
            }
        ]
    },
    {
        id: 3,
        description: null,
        type: 'scenario',
        introVideo: [{
                path: 'shrink-dream.webm',
                ambiencePath: null
            },
            {
                path: 'spooky-intro.webm',
                ambiencePath: 'ambience-spooky-outside.mp3'
            }
        ],
        answers: [{
                id: 6,
                content: 'Enter',
                outroVideo: [{
                    path: 'spooky-enter.webm',
                    ambiencePath: 'ambience-spooky-outside.mp3'
                }],
                followUp: null
            },
            {
                id: 7,
                content: 'Leave',
                outroVideo: [{
                    path: 'spooky-leave.webm',
                    ambiencePath: 'ambience-spooky-outside.mp3'
                }],
                followUp: null
            }
        ]
    }
];

export class DreamApi {
    constructor(baseUrl) {
        this.baseUrl = baseUrl;
    }

    getQuestions() {
        return Promise.resolve(questions);
        // return fetch(`${this.baseUrl}/question`);
    }
}