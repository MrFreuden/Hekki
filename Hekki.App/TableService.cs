using Hekki.Domain.Interfaces;
using Hekki.Domain.Models;

namespace Hekki.App
{
    public class TableService
    {
        private readonly Regulation _regulation;
        private readonly List<Pilot> _pilots;

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
                Heats = BuildHeatTables(),
                PilotViewModels = _pilots
                .Select(pilot => new PilotGeneralDTO(pilot.Name, [.. pilot.UsedKarts], [.. pilot.Results]))
                .ToList()
            };
            return regulationViewModel;
            
        }

        public List<HeatViewModel> BuildHeatTables()
        {
            var heats = _regulation.HeatResults
                .Select((heatResult, index) => new HeatViewModel(
                    index, _regulation.MaxGroupCapacity, new List<HeatColumnViewModel>
                        { new HeatColumnViewModel(heatResult.Label, heatResult.GetType()) }))
                .ToList();
            return heats;
        }
    }
    public class RegulationViewModel
    {
        public int HeatCount { get; set; }
        public List<HeatViewModel> Heats { get; set; } = new();
        public List<PilotGeneralDTO> PilotViewModels { get; set; } = new();
    }

    public class PilotGeneralDTO
    {
        public PilotGeneralDTO(string name, List<int> usedKarts, List<IResult> results)
        {
            Name = name;
            UsedKarts = usedKarts;
            Results = results;
        }

        public string Name { get; }
        public List<int> UsedKarts { get; } = new();
        public List<IResult> Results { get; } = new();
    }
    public class PilotHeatDTO
    {
        public PilotHeatDTO(string name, int usedKart, IResult result)
        {
            Name = name;
            UsedKart = usedKart;
            Result = result;
        }

        public string Name { get; }
        public int UsedKart { get; }
        public IResult Result { get; }
    }
    public class HeatGeneralDTO
    {
        public HeatGeneralDTO(int heatIndex, List<HeatColumnViewModel> columns)
        {
            HeatIndex = heatIndex;
            Columns = columns;
        }

        public int HeatIndex { get; }
        public List<HeatColumnViewModel> Columns { get; } = new();
    }
    public class HeatHeatDTO
    {
        public HeatHeatDTO(int heatIndex, List<HeatColumnViewModel> columns, int maxGroupCapacity, int groupsCount = 3)
        {
            HeatIndex = heatIndex;
            Columns = columns;
            MaxGroupCapacity = maxGroupCapacity;
            GroupsCount = groupsCount;
        }

        public int HeatIndex { get; }
        public int MaxGroupCapacity { get; }
        public int GroupsCount { get; }
        public List<HeatColumnViewModel> Columns { get; } = new();
    }
    public class HeatViewModel
    {
        public HeatViewModel(int heatIndex, int maxGroupCapacity, List<HeatColumnViewModel> columns, int groupsCount = 5)
        {
            HeatIndex = heatIndex;
            MaxGroupCapacity = maxGroupCapacity;
            Columns = columns;
            GroupsCount = groupsCount;
        }

        public int HeatIndex { get; }
        public int MaxGroupCapacity { get; }
        public int GroupsCount { get; }
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

