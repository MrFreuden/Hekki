using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelController.Services;
using RaceLogic.Algorithms;
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
            SetSortMethod(new SortShuffle());
            var indexedPilots = _pilots.Select((pilot, index) => new { Pilot = pilot, Index = index }).ToList();
            var preparedPilots = PreparePilots();

            var karts = _regulation.GetCombos(preparedPilots, _numberKarts);
            _pilotService.AddKarts(preparedPilots, karts);

            var names = _pilotService.GetNames(preparedPilots);
            _raceDataService.WriteDataInfoInRace(names, "Пілоти");
            _raceDataService.WriteDataInfoInRace(karts, "Карт");
            _pilots = indexedPilots.OrderBy(x => x.Index).Select(x => x.Pilot).ToList();
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
            var names = _raceDataService.ReadNamesInBoard();
            var countPilots = names.Count;
            var kartsMerged = _raceDataService.ReadUsedKartsInBoard(countPilots);
            var scoresMerged = _raceDataService.ReadResultsInBoard("Хіт", countPilots);
            var timesMerged = _raceDataService.ReadResultsInBoard("Best Lap", countPilots);
            var liques = _raceDataService.ReadLiquesInBoard(countPilots);

            _pilots = _pilotService.CreatePilots(names, kartsMerged, scoresMerged, timesMerged, liques);
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
