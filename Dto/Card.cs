using PokerConsole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerConsole.Dto
{
    public class Card
    {
        private int _cardReference;
        public int CardReference
        {
            set
            {
                _cardReference = value;
            }
            get
            {
                return _cardReference;
            }
        }
        public string Symbole
        {
            get
            {
                return FixedData.symboleDico.FirstOrDefault(x => x.Key == _cardReference % 10).Value;
            }
        }

        public string NumberString
        {
            get
            {
                return FixedData.dicoNumberString.FirstOrDefault(x => x.Key == _cardReference / 10).Value;
            }
        }
    }
}
