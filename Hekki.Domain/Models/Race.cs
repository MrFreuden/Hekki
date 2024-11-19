using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hekki.Domain.Models
{
    public class Race
    {
        private List<Pilot> _pilots;
        private List<Heat> _heats;
        private Regulation _regulation;

        public Race(List<Pilot> pilots, List<Heat> heats, Regulation regulation)
        {
            _pilots = pilots;
            _heats = heats;
            _regulation = regulation;
        }
    }
}
