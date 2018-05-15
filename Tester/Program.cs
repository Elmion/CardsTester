using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
    class Program
    {
        public static readonly Random rnd = new Random();
        static void Main(string[] args)
        {
           while(1==1)
            {
                Game();
                Console.ReadLine();
            }
        }
        static void Game()
        {
            Console.Clear();
            CardDesk d = new CardDesk();
            d.MixDesk(100000);
            Player p1 = new Player();
            Player p2 = new Player();
            Player p3 = new Player();
            Player p4 = new Player();
            Player p5 = new Player();
            Board b = new Board();
            b.PutCard(d.GetCardOnTop());
            b.PutCard(d.GetCardOnTop());
            b.PutCard(d.GetCardOnTop());
            b.PutCard(d.GetCardOnTop());
            b.PutCard(d.GetCardOnTop());
            p1.PutCardHand(d.GetCardOnTop());
            p1.PutCardHand(d.GetCardOnTop());
            p2.PutCardHand(d.GetCardOnTop());
            p2.PutCardHand(d.GetCardOnTop());
            p3.PutCardHand(d.GetCardOnTop());
            p3.PutCardHand(d.GetCardOnTop());
            p4.PutCardHand(d.GetCardOnTop());
            p4.PutCardHand(d.GetCardOnTop());
            p5.PutCardHand(d.GetCardOnTop());
            p5.PutCardHand(d.GetCardOnTop());
            PrintPlayer(p1, b);
            PrintPlayer(p2, b);
            PrintPlayer(p3, b);
            PrintPlayer(p4, b);
            PrintPlayer(p5, b);
        }
        private static void PrintPlayer(Player p1, Board b)
        {

            for (int i = 0; i < b.Desktop.Count; i++)
            {
                Console.Write(b.Desktop[i].ToString() + " ");
            }
            Console.Write("+ ");
            for (int i = 0; i < p1.Hand.Count; i++)
            {
                Console.Write(p1.Hand[i].ToString() + " ");
            }
            Console.Write( "= ");
            Console.Write(TestCombine.Test(b, p1));
            Console.WriteLine();
        }

    }
}
