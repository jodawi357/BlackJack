using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackRepo
{
    public class Card
    {
        public int Value { get; set; }
        public string Suit { get; set; }
        public Card(int value, string suit)
        {
            Value = value;
            Suit = suit;
        }
    }
}
