using Hekki.Domain.Models;

namespace Hekki.App
{
    public class TableService
    {
        public GeneralTableDTO BuildGeneralTable(List<Heat> heats, Pilots pilots)
        {
            var table = new GeneralTableDTO();
            foreach (var heat in heats)
            {
                table.Columns.Add(heat.HeatResult.Label);
            }
            foreach (var pilot in pilots)
            {
                var row = new GeneralTableRowDTO()
                {
                    PilotName = pilot.Name,
                    PilotUsedKarts = string.Join(" ", pilot.UsedKarts.Select(x => x.ToString())),
                };
                foreach (var result in pilot.Results)
                {

                }
            }

            return table;
        }

        public List<HeatTableDTO> BuildHeatTable(List<Heat> heats, Pilots pilots)
        {
            throw new NotImplementedException();
        }
    }

    public class GeneralTableDTO
    {
        public List<string> Columns { get; set; } = new();
        public List<GeneralTableRowDTO> Rows { get; set; } = new();
    }

    public class GeneralTableRowDTO
    {
        public string PilotName { get; set; }
        public string PilotUsedKarts { get; set; }
    }

    public class HeatTableDTO
    {

    }
}
