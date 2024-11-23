using Hekki.Domain.Interfaces;
using Hekki.Domain.Models;

namespace Hekki.App
{
    public class TableService
    {
        private Regulation _regulation;
        private List<Pilot> _pilots;

        public TableService(Regulation regulation, List<Pilot> pilots)
        {
            _regulation = regulation;
            _pilots = pilots;
        }

        public RegulationViewModel BuildGeneralTable()
        {
            var regulationViewModel = new RegulationViewModel
            {
                HeatCount = _regulation.HeatCount,
                Heats = _regulation.HeatResults
                .Select((heatResult, i) => new HeatViewModel(
                    i,
                    _regulation.MaxGroupCapacity,
                    new List<HeatColumnViewModel>
                    {
                        new HeatColumnViewModel(heatResult.Label, heatResult.GetType())
                    }))
                .ToList(),
                PilotViewModels = _pilots
                .Select(pilot => new PilotViewModel(pilot.Name, [.. pilot.UsedKarts], [.. pilot.Results]))
                .ToList()
            };
            return regulationViewModel;
            
        }
        //public List<HeatTableDTO> BuildHeatTable(List<Heat> heats, Pilots pilots)
        //{
        //    throw new NotImplementedException();
        //}
    }
    public class RegulationViewModel
    {
        public int HeatCount { get; set; }
        public List<HeatViewModel> Heats { get; set; } = new();
        public List<PilotViewModel> PilotViewModels { get; set; } = new();
    }

    public class PilotViewModel
    {
        public PilotViewModel(string name, List<int> usedKarts, List<IResult> results)
        {
            Name = name;
            UsedKarts = usedKarts;
            Results = results;
        }

        public string Name { get; }
        public List<int> UsedKarts { get; } = new();
        public List<IResult> Results { get; } = new();
    }

    public class HeatViewModel
    {
        public HeatViewModel(int heatIndex, int maxGroupCapacity, List<HeatColumnViewModel> columns)
        {
            HeatIndex = heatIndex;
            MaxGroupCapacity = maxGroupCapacity;
            Columns = columns;
        }

        public int HeatIndex { get; }
        public int MaxGroupCapacity { get; }
        public List<HeatColumnViewModel> Columns { get; } = new();
    }
    public class HeatColumnViewModel
    {
        public HeatColumnViewModel(string name, Type dataType)
        {
            Name = name;
            DataType = dataType;
        }

        public string Name { get; }
        public Type DataType { get; }
    }
}

