using PokerConsole.Dto;
using PokerConsole.Dto.Values;
using PokerConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerConsole.Services
{
    class FixedData
    {
        static public IDictionary<int, string> dicoNumberString
        {
            get
            {
                return new Dictionary<int, string>() {
                {1, "As" },
                {2, "Deux" },
                {3, "Trois" },
                {4, "Quatre" },
                {5, "Cinq" },
                {6, "Six" },
                {7, "Sept" },
                {8, "Huit" },
                {9, "Neuf" },
                {10, "Dix" },
                {11, "Valet" },
                {12, "Dame" },
                {13, "Roi" },
            };
            }
        }
        static public IDictionary<int, int> dicoGenerateReferenceNumber
        {
            get
            {
                return new Dictionary<int, int>() {
                {1, 10 },
                {2, 20 },
                {3, 30 },
                {4, 40 },
                {5, 50 },
                {6, 60 },
                {7, 70 },
                {8, 80 },
                {9, 90 },
                {10, 100 },
                {11, 110 },
                {12, 120 },
                {13, 130 },
            };
            }
        }
        static public IDictionary<int, string> symboleDico
        {
            get
            {
                return new Dictionary<int, string>() {
                {1, "♦" },
                {2, "♥" },
                {3, "♣ " },
                {4, "♠" },
            };
            }
        }
        static public IDictionary<Type, int> CombinaisonValue
        {
            get
            {
                return new Dictionary<Type, int>() 
                {
                    {typeof(High),1},
                    {typeof(Pair),2},
                    {typeof(TwoPair),3},
                    {typeof(Set), 4},
                    {typeof(Straight),5},
                    {typeof(Flush),6 },
                    {typeof(Full),7 },
                    {typeof(StraightFlush),8},
                };

            }
        }
        static public IEnumerable<int> Deck
        {
            get
            {
                List<int> temp = new List<int>();
                foreach (KeyValuePair<int, int> number in dicoGenerateReferenceNumber)
                {
                    foreach (KeyValuePair<int, string> color in symboleDico)
                    {
                        temp.Add(number.Value + color.Key);
                    }
                }
                return temp.OrderBy(x => Guid.NewGuid().ToString("N"));
            }

        }
    }
}
