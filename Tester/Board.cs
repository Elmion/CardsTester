using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
    public class Board
    {
        public List<Card> Desktop { get; private set; }
        public Board()
        {
            Desktop = new List<Card>();
        }
        public void PutCard(Card c)
        {    
            Desktop.Add(c);
        }
    }
}
