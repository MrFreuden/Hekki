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
        private IRaceDataService _raceDataService;
        private IPilotService _pilotService;

        private List<IPilot> _pilots;
        private List<int> _numberKarts;

        public Race(IRegulation regulation, IRaceDataService raceDataService, IPilotService pilotService, IEnumerable<IPilot> pilots, List<int> numberKarts)
        {
            _regulation = regulation;
            _raceDataService = raceDataService;
            _pilotService = pilotService;
            _numberKarts = numberKarts;
            _pilots = pilots.Any() ? pilots.ToList() : CreatePilots();

        }

        private List<IPilot> CreatePilots()
        {
            var names = _raceDataService.ReadNamesInBoard();
            return _pilotService.CreatePilots(names);
        }

        public void MakeHeat()
        {
            var preparedPilots = PreparePilots();

            var karts = _regulation.GetCombos(preparedPilots, _numberKarts);
            _pilotService.AddKarts(preparedPilots, karts);

            var names = _pilotService.GetNames(preparedPilots);
            _raceDataService.WriteDataInfoInRace(names, "Пілоти");
            _raceDataService.WriteDataInfoInRace(karts, "Карт");
        }

        private List<List<IPilot>> PreparePilots()
        {
            _regulation.Sort(_pilots);
            var devided = _regulation.Devide(_pilots, GroupAmount);
            return devided;
        }

        public void SortBoardByScore()
        {
            _raceDataService.SortTable("Сума");
        }

        public void SortBoardByTime()
        {
            _raceDataService.SortTable("Час");
        }

        public void TransferScoresToBoard()
        {
            var scores = _raceDataService.ReadResultsInRace("Разом", PilotsCount);
            for (int i = 0; i < scores.Count; i++)
            {
                _raceDataService.WriteDataInfoInBoard(scores[i], "ХІТ", i);
            }
        }

        public void TransferTimesToBoard()
        {
            var times = _raceDataService.ReadResultsInRace("Час", PilotsCount);
            for (int i = 0; i < times.Count; i++)
            {
                _raceDataService.WriteDataInfoInBoard(times[i], "Best Lap", i);
            }
        }

        public void RebuildAll()
        {
            throw new NotImplementedException();
        }

        public void ClearAll()
        {
            _raceDataService.ClearExcelData();
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
