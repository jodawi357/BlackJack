using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackRepo
{
    public class CardRepo
    {
        Random rando = new Random();
        List<Card> _deck = new List<Card>();
        List<Card> _discard = new List<Card>();
        List<Card> _playerHand = new List<Card>();
        List<Card> _dealerHand = new List<Card>();

        public Card CreateCard(int value, string suit)
        {
            Card card = new Card(value, suit);
            return card;
        }
        public void AddToDeck(Card card)
        {
            _deck.Add(card);
        }
        public List<Card> GetDeck()
        {
            return _deck;
        }
          public void DiscardBothHands()
        {
            _playerHand.Clear();
            _dealerHand.Clear();
        }
        public bool CreateDeck() //Change suits to int and make ONE loop
        {
            if (_deck.Count < 15)
            {
                _deck.Clear();
                for (int i = 1; i <= 13; i++)
                {
                    Card card = new Card(i, "Clubs");
                    _deck.Add(card);
                }
                for (int i = 1; i <= 13; i++)
                {
                    Card card = new Card(i, "Hearts");
                    _deck.Add(card);
                }
                for (int i = 1; i <= 13; i++)
                {
                    Card card = new Card(i, "Spades");
                    _deck.Add(card);

                }
                for (int i = 1; i <= 13; i++)
                {
                    Card card = new Card(i, "Diamonds");
                    _deck.Add(card);
                }
                return true;
            }
            return false;
        }
        public bool Reshuffle()
        {
            if(_deck.Count < 15)
            {
                foreach (Card card in _discard)
                {
                    _discard.Remove(card);
                    _deck.Add(card);
                    return true;
                }

            }
            return false;
        }
        public Card DrawACard()
        {
            int deckCount = _deck.Count();
            int rCard = rando.Next(1, (deckCount));
            Card card = _deck[rCard];
            _deck.Remove(card);
            return card;
        }
        public void DealPlayer()
        {
            _playerHand.Add(DrawACard());
        }
        public void DealDealer()
        {
            _dealerHand.Add(DrawACard());
        }
        public void DealOpen()
        {
            DealPlayer();
            DealDealer();
            DealPlayer();
            DealDealer();
        }
        public List<Card> GetPlayerHand()
        {
            return _playerHand;
        }//2 methods???
        public List<Card> GetDealerHand()
        {
            return _dealerHand;
        }//2 methods???
        public int ScoreHand(List<Card> hand)
        {
            int score = ScoreCards(hand);
            bool hasAce = false;
            if (score < 12)
            {
                foreach(Card card in hand)
                {
                    if(card.Value == 1) { hasAce = true; }
                }
                if(hasAce == true)
                {
                    score += 10;
                }
            }
            return score;
        }
        public int ScoreCard(Card card)
        {
            switch (card.Value)
            {
                case 11:
                    return 10;
                case 12:
                    return 10;
                case 13:
                    return 10;
                default:
                    return card.Value;
            }
        }
        public string CheckHand(List<Card> hand)
        {
            if (ScoreHand(hand) > 21) { return "bust"; }
            if (ScoreHand(hand) == 21) { return "21"; }
            return null;
        }
        //public string CompareHands(List<Card> player, List<Card> dealer)
        //{
        //    return (ScoreHand(player) > ScoreHand(dealer)) ? "player" : "dealer";
        //}
        public bool DealerTurn()
        {
            
            while(1 > 0)
            {
                if(ScoreHand(_dealerHand) < ScoreHand(_playerHand) || ScoreHand(_dealerHand) < 17)
                {
                    DealDealer();
                    string checkHand = CheckHand(_dealerHand);
                    switch (checkHand)
                    {
                        case "bust":
                            return true;
                        case "21":
                            return false;
                        default:
                            break;
                    }
                    
                }
                else
                {
                    return false;
                }
            }
        }
        public int ScoreCards(List<Card> hand)
            {
                int score = 0;
                foreach (Card card in hand)
                {
                    score += ScoreCard(card);
                }
                return score;
            }
    }
}