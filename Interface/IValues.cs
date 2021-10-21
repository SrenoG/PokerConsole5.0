using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerConsole.Interface
{
    public interface IValues
    {
        public int Val { get; }
        public List<int> RestOfHand { get; set; }
    }
}
