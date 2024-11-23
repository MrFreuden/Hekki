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

            var regulationViewModel = new RegulationViewModel();
            regulationViewModel.HeatCount = _regulation.HeatCount;
            var heats = new List<HeatViewModel>();
            int i = 0;
            foreach (var heat in _regulation.HeatResults)
            {
                heats.Add(new HeatViewModel(i, _regulation.MaxGroupCapacity, [new HeatColumnViewModel(heat.Label, heat.GetType())]));
                i++;
            }

            regulationViewModel.Heats = heats;

            var pilotsViewModel = new List<PilotViewModel>();
            foreach (var pilot in _pilots)
            {
                pilotsViewModel.Add(new PilotViewModel(pilot.Name, [.. pilot.UsedKarts], new PilotRowViewModel([.. pilot.Results])));
            }

            regulationViewModel.PilotViewModels = pilotsViewModel;

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
        public PilotViewModel(string name, List<int> usedKarts, PilotRowViewModel rowViewModel)
        {
            Name = name;
            UsedKarts = usedKarts;
            RowViewModel = rowViewModel;
        }

        public string Name { get; set; }
        public List<int> UsedKarts { get; set; } = new();
        public PilotRowViewModel RowViewModel { get; set; }
    }

    public class PilotRowViewModel
    {
        public PilotRowViewModel(List<IResult> results)
        {
            Results = results;
        }

        public List<IResult> Results {  get; set; } = new();
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

