using PokerConsole.Dto.Values;
using PokerConsole.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerConsole.Dto
{
    public class Full : Value
    {
        public Set Set { get; set; }
        public Pair Pair { get; set; }
    }
}
