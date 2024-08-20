using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceLogic.Interfaces;

namespace RaceLogic.Models
{
    public class Race : IRace
    {
        public int KartsCount { get => _numberKarts.Count; }
        public int PilotsCount { get => _pilots.Count; }
        public int GroupAmount { get => (int)Math.Ceiling((double)PilotsCount / KartsCount); }

        private IRegulation _regulation;
        private IRaceDataService _service;
        private IPilotService _pilotService;

        private List<IPilot> _pilots;
        private List<int> _numberKarts;
        private List<int> _groupsСapacity;

        public Race(IRegulation regulation, IRaceDataService service, IEnumerable<IPilot> pilots, List<int> numberKarts)
        {
            _regulation = regulation;
            _service = service;
            _pilots = pilots.ToList();
            _numberKarts = numberKarts;
        }

        public void MakeHeat()
        {
            var preparedPilots = PreparePilots();

            var karts = _regulation.GetCombos(preparedPilots, _numberKarts);
            _pilotService.AddKarts(preparedPilots, karts);

            var names = _pilotService.GetNames(preparedPilots);
            _service.WriteDataInfoInRace(names, "Пілоти");
            _service.WriteDataInfoInRace(karts, "Карт");
        }

        private List<List<IPilot>> PreparePilots()
        {
            _regulation.Sort(_pilots);
            var devided = _regulation.Devide(_pilots, GroupAmount);
            SetGroupsСapacity(devided);
            return devided;
        }

        private void SetGroupsСapacity(List<List<IPilot>> list)
        {
            var groupsCapacity = new List<int>();
            foreach (var group in list)
            {
                groupsCapacity.Add(group.Count);
            }
            _groupsСapacity = groupsCapacity;
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
            var scores = _service.ReadResultsInRace("Разом", PilotsCount);
            for (int i = 0; i < scores.Count; i++)
            {
                _service.WriteDataInfoInBoard(scores[i], "ХІТ", i);
            }
        }

        public void TransferTimesToBoard()
        {
            var times = _service.ReadResultsInRace("Час", PilotsCount);
            for (int i = 0; i < times.Count; i++)
            {
                _service.WriteDataInfoInBoard(times[i], "Best Lap", i);
            }
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
            _regulation.SetDevideMethod(devideMethod);
        }

        public void SetSortMethod(ISortMethod sortMethod)
        {
            _regulation.SetSortMethod(sortMethod);
        }
    }
}
