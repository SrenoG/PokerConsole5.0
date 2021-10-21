using PokerConsole.Interface;
using PokerConsole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerConsole.Dto.Values
{
    public class Value : IValues
    {
        public int Val
        {
            get
            {
                return FixedData.CombinaisonValue.FirstOrDefault(x => x.Key == this.GetType()).Value;
            }
        }

        public List<int> RestOfHand { get; set; }
    }
}
