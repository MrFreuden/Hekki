using Hekki.App.DTO;
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

        public List<HeatDTO> BuildHeatTables()
        {
            var heats = _regulation.HeatResults
                .Select((heatResult, index) => new HeatDTO(
                    index, new List<HeatColumnViewModel>
                        { new HeatColumnViewModel(heatResult.Label, heatResult.GetType()) }, 
                    _regulation.MaxGroupCapacity))
                .ToList();
            return heats;
        }
    }
    public class RegulationViewModel
    {
        public int HeatCount { get; set; }
        public List<HeatDTO> Heats { get; set; } = new();
        public List<PilotGeneralDTO> PilotViewModels { get; set; } = new();
    }
}

