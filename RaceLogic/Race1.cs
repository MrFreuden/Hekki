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
        public int KartsCount { get => _numberKarts.Count; }
        public int PilotsCount { get => _pilots.Count; }
        public int GroupAmount { get => (int)Math.Ceiling((double)PilotsCount / KartsCount); }
        private IRegulation _regulation;
        private IRaceDataService _service;
        private List<IPilot> _pilots;
        private List<int> _numberKarts;
        private ISortMethod _sortMethod;
        private IDevideMethod _devideMethod;
        private IPilotService _pilotService;

        public ISortMethod SortMethod => _sortMethod;

        public IDevideMethod DevideMethod => _devideMethod;

        public Race1(IRegulation regulation, IRaceDataService service, IEnumerable<IPilot> pilots, List<int> numberKarts)
        {
            _regulation = regulation;
            _service = service;
            _pilots = pilots.ToList();
            _numberKarts = numberKarts;
        }

        public void MakeHeat()
        {
            _regulation.Sort(_pilots);
            var devided = _regulation.Devide(_pilots, GroupAmount);
            var karts = _regulation.GetCombos(devided, _numberKarts);
            _pilotService.AddKarts(devided, karts);
            var names = _pilotService.GetNames(devided);
            _service.WriteDataInfoInRace(names, "");
            _service.WriteDataInfoInRace(karts, "");
        }

        public void SortBoardByScore()
        {
            _service.SortTable("Сума");
        }

        public void SortBoardByTime()
        {
            _service.SortTable("Час");
        }

        public void TransferScoresToBoard()
        {
            var scores = _service.ReadColScoresInRace();
            _service.WriteScoresInBoard(scores);
        }

        public void TransferTimesToBoard()
        {
            var times = _service.ReadColTimesInRace();
            _service.WriteTimesInBoard(times);
        }

        public void RebuildAll()
        {
            throw new NotImplementedException();
        }

        public void ClearAll()
        {
            _service.ClearExcelData();
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
