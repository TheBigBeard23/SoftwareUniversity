const getCard = require('../02.PlayingCards/playingCards.js');

function printDeckOfCards(cards) {
    let result = "";

    for (let card of cards) {
        try {
            result += getCard(card.substring(0, card.length - 1), card[card.length - 1]) + '\n';
        } catch (error) {
            result = `Invalid card: ${card}`;
        }
    }
    console.log(result);
}

printDeckOfCards(['AS', '10D', 'KH', '2C']);