const getCard = require('../02.PlayingCards/playingCards.js');

function printDeckOfCards(cards) {
    let result = "";

    for (let card of cards) {
        try {
            result += solve(card.substring(0, card.length - 1), card[card.length - 1]) + '\n';
        } catch (error) {
            result = `Invalid card: ${card}`;
        }
    }
    console.log(result);

    function solve(face, suit) {

        const faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

        const suits = {
            S: '\u2660 ',
            H: '\u2665 ',
            D: '\u2666 ',
            C: '\u2663 '
        }

        if (!faces.includes(face)) {
            throw new TypeError('Invalid face: ' + face);
        }
        if (!suits[suit]) {
            throw new Error('Invalid suit: ' + suit);
        }

        return {
            face,
            suit: suits[suit],
            toString() {
                return this.face + this.suit;
            }
        };
    }
}

printDeckOfCards(['AS', '10D', 'KH', '2C']);