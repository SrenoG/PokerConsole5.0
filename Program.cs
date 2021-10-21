using PokerConsole.Dto;
using PokerConsole.Dto.Values;
using PokerConsole.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerConsole
{
    class Program
    {

        // Main method.
        static int[] DeckCount = new int[52];
        public static void Main()
        {
            bool again = true;
            while (again)
            {
                List<int> distCard = new List<int>();
                List<int> boardCard = new List<int>();
                int numberOfPlayer = 2;
                List<Player> playerList = CreatePlayer(numberOfPlayer, distCard).ToList();
                PrintPlayerCard(playerList);
                WriteBoard("FLOP", 3, distCard, boardCard);
                WriteBoard("TURN", 1, distCard, boardCard);
                WriteBoard("RIVER", 1, distCard, boardCard);
                Player winner = GetWinner(playerList, boardCard);
                again = SetAgain();
            }
            //Roll.rngCsp.Dispose();
        }

        private static Player GetWinner(List<Player> playerList, List<int> boardCard)
        {
            foreach (Player player in playerList)
            {
                List<int> maxCard = new List<int>();
                maxCard.Add(player.Hand.Card1.CardReference);
                maxCard.Add(player.Hand.Card2.CardReference);
                foreach (int cardRef in boardCard)
                {
                    maxCard.Add(cardRef);
                }

                player.BestHand = GetBestHand(maxCard);
            }
            return null;

        }


        private static BestHand GetBestHand(List<int> maxCard)
        {
            List<int> test = new List<int>() { 101, 11, 21, 51, 41, 31, 81 };
            List<Value> ListValue = new List<Value>();

            var queryPairSetSquare = maxCard.GroupBy(x => x / 10)
              .Where(g => g.Count() > 1)
              .ToDictionary(x => x.Key, y => y.Count());

            foreach (KeyValuePair<int,int> item in queryPairSetSquare)
            {
                if (item.Value == 2)
                    ListValue.Add(new Pair() { Value = item.Key });
                if (item.Value == 3)
                    ListValue.Add(new Set() { Value = item.Key });
                if (item.Value == 4)
                    ListValue.Add(new Square() { Value = item.Key });
            }


            var queryFlush = test.GroupBy(x => x % 10)
                .Where(g => g.Count() >= 5)
                .FirstOrDefault(x => x.Key == 1)
                .OrderByDescending(x => x)
                .Take(5)
                .ToList();


            //foreach (List<IGrouping<int, int>> item in queryFlush)
            //{

            //}

            var queryStraight = test.OrderBy(x => x)
                .GroupWhile((x, y) => y/10 - x/10 == 1)
                 .Where(x => x.Count() >= 5)
                 .ToList();

            var queryStraightFlush = queryFlush.OrderByDescending(x=> x);



            foreach (int item in maxCard)
            {

            }
            return null;
        }

        private static void PrintPlayerCard(List<Player> playerList)
        {
            foreach (Player player in playerList)
            {
                Console.Clear();
                Console.WriteLine("-------------------");
                Console.WriteLine("NOM     : " + player.Name);
                Console.WriteLine("CARTE 1 : " + getCard(player.Hand.Card1));
                Console.WriteLine("CARTE 2 : " + getCard(player.Hand.Card2));
                Console.WriteLine("-------------------");
            }
        }
        private static bool SetAgain()
        {
            string read = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Main suivante ? Y ou N");
                read = Console.ReadLine().ToLower();
            }
            while (read != "y" && read != "n");
            if (read == "y")
                return true;
            else
                return false;
        }
        private static void WriteBoard(string v1, int v2, List<int> distCard, List<int> boardCard)
        {
            Console.WriteLine("--------------");
            Console.WriteLine(v1 + " :");
            Console.WriteLine("--------------");
            for (int i = 0; i < v2; i++)
            {
                Console.WriteLine(getCard(GenerateCard(distCard, boardCard)));
            }
            //Console.WriteLine("Continue?");
            //Console.ReadKey();
        }
        private static IEnumerable<Player> CreatePlayer(int numberOfPlayer, List<int> distCard)
        {
            for (int i = 1; i <= numberOfPlayer; i++)
            {
                yield return new Player()
                {
                    Name = "Player" + i,
                    Hand = new Hand()
                    {
                        Card1 = GenerateCard(distCard),
                        Card2 = GenerateCard(distCard)
                    }
                };
            }
        }
        private static Card GenerateCard(List<int> distCard)
        {
            Card card = new Card();
            int tmp;
            do
            {
                tmp = FixedData.Deck.ToList()[Roll.RollDice((byte)DeckCount.Length)];
            }
            while (distCard.Contains(tmp));
            //TODO: CardReference had accessor now => to improve
            card.CardReference = tmp;
            distCard.Add(tmp);
            return card;
        }
        private static Card GenerateCard(List<int> distCard, List<int> boardCard)
        {
            Card card = new Card();
            int tmp;
            do
            {
                tmp = FixedData.Deck.ToList()[Roll.RollDice((byte)DeckCount.Length)];
            }
            while (distCard.Contains(tmp));
            card.CardReference = tmp;
            distCard.Add(tmp);
            boardCard.Add(tmp);
            return card;
        }
        static protected string getCard(Card card)
        {
            return card.NumberString + card.Symbole;
        }
    }
}

  
