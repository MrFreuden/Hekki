using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceLogic.Interfaces;

namespace RaceLogic
{
    public class Race1 : IRace
    {
        private IRegulation _regulation;
        private IRaceService _service;
        private List<IPilot> _pilots;
        private List<int> _numberKarts;

        public Race1(IRegulation regulation, IRaceService service, IEnumerable<IPilot> pilots, List<int> numberKarts)
        {
            _regulation = regulation;
            _service = service;
            _pilots = pilots.ToList();
            _numberKarts = numberKarts;
        }

        public void MakeHeat()
        {
            throw new NotImplementedException();
        }

        public void SortPilots()
        {
            throw new NotImplementedException();
        }

        public void SortScores()
        {
            throw new NotImplementedException();
        }

        public void SortTimes()
        {
            throw new NotImplementedException();
        }

        public void TransferScoresToBoard()
        {
            throw new NotImplementedException();
        }

        public void TransferTimesToBoard()
        {
            throw new NotImplementedException();
        }
    }
}
