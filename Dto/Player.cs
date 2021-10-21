using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerConsole.Dto
{
    public class Player
    {
        public BestHand BestHand;
        public string Name { get; set; }
        private Hand _hand;
        public Hand Hand
        {
            get
            {
                if (_hand == null)
                    return new Hand();
                else
                    return _hand;
            }
            set
            {
                _hand = value;
            }
        }
    }
}
