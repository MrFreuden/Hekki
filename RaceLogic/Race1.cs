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
        private ISortMethod _sortMethod;
        private IDevideMethod _devideMethod;
        private IPilotService _pilotService;
        private int _groupAmount;
        public ISortMethod SortMethod => _sortMethod;

        public IDevideMethod DevideMethod => _devideMethod;

        public Race1(IRegulation regulation, IRaceService service, IEnumerable<IPilot> pilots, List<int> numberKarts)
        {
            _regulation = regulation;
            _service = service;
            _pilots = pilots.ToList();
            _numberKarts = numberKarts;
        }

        

        public void RebuildAll()
        {
            throw new NotImplementedException();
        }

        

        public void SortBoardByScore()
        {
            throw new NotImplementedException();
        }

        public void SortBoardByTime()
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

        public void SetDevideMethod(IDevideMethod devideMethod)
        {
            _devideMethod = devideMethod;
        }

        public void SetSortMethod(ISortMethod sortMethod)
        {
            _sortMethod = sortMethod;
        }
    }
}
