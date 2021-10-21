using PokerConsole.Dto.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerConsole.Dto
{
    public class BestHand
    {
        public int[] Cards = new int[5];
        public Value Value { get; set; }
    }
}
