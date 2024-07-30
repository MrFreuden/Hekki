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
        public int MaxKarts { get; }
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
            MaxKarts = 10;  // TODO: передавать из формы. Сделать, что бы можно было менять во время гонки
            _regulation = regulation;
            _service = service;
            _pilots = pilots.ToList();
            _numberKarts = numberKarts;
            _service.ExcelWriter.GroupAmount = _groupAmount;
        }

        public void MakeHeat()
        {
            _regulation.Sort(_pilots, _sortMethod);
            var devided = _regulation.Devide(_devideMethod, _groupAmount);
            var karts = _regulation.GetCombos(devided);
            _pilotService.AddKarts(devided, karts);
            var names = _pilotService.GetNames(_pilots);
            _service.ExcelWriter.WriteNamesInRace(names);
            _service.ExcelWriter.WriteUsedKartsInRace(karts);
        }

        public void SortBoardByScore()
        {
            _service.ExcelHelper.SortTable("Сума");
        }

        public void SortBoardByTime()
        {
            _service.ExcelHelper.SortTable("Час");
        }

        public void TransferScoresToBoard()
        {
            var scores = _service.ExcelReader.ReadScoresInRace();
            _service.ExcelWriter.WriteScoresInBoard(scores);
        }

        public void TransferTimesToBoard()
        {
            var times = _service.ExcelReader.ReadTimesInRace();
            _service.ExcelWriter.WriteTimesInBoard(times);
        }

        public void RebuildAll()
        {
            throw new NotImplementedException();
        }

        public void ClearAll()
        {
            _service.ExcelHelper.ClearExcelData();
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
