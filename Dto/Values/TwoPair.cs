using PokerConsole.Dto.Values;
using PokerConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerConsole.Dto
{
    public class TwoPair : Value
    {
        public Pair Pair1 { get; set; }
        public Pair Pair2 { get; set; }

    }
}
