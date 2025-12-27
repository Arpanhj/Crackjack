
# Playing cards, card decks

The game is played with regular playing cards, four suits with cards 2,3,4,5,6,7,8,9,10 with face value, J,Q,K with the value of 10, and A with the value of 11, unless the same hand holds two A's, in which case one of them holds the value of 1 (bringing the total to 12).

## the Card class

The card class is a class that playing cards derive from. It holds the suite, the value, and a png image of the card.

    class Card {
        enum Suite;
        Suite suite;

        enum Value;
        Value value;
    }

## the Deck class

    class Deck {
        public List<Card> deck;

        
    }
