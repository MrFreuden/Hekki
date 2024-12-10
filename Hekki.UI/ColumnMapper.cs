using Hekki.App.DTO;
using Hekki.Domain.Models;

namespace Hekki.UI
{
    public class ColumnMapper
    {
        public string HeaderText { get; set; }
        public Func<PilotDTO, string> Formatter { get; set; }
        public Action<PilotDTO, string> Parser { get; set; }
        public int HeatIndex { get; set; }
        public string ColumnName { get; set; }

        public List<ColumnMapper> GenerateColumnMappers(List<HeatDTO> heatDTOs)
        {
            var mappers = new List<ColumnMapper>();

            mappers.Add(new ColumnMapper
            {
                HeaderText = "Used Karts",
                Formatter = pilot => string.Join(", ", pilot.UsedKarts ?? new List<int>()),
                Parser = (pilot, input) =>
                {
                    pilot.UsedKarts = new Karts(input.Split(',')
                        .Select(kart => int.TryParse(kart.Trim(), out var num) ? num : 0)
                        .ToList());
                }
            });

            mappers.Add(new ColumnMapper
            {
                HeaderText = "Pilot Name",
                Formatter = pilot => pilot.Name,
                Parser = (pilot, input) => pilot.Name = input
            });

            for (int heatIndex = 0; heatIndex < heatDTOs.Count; heatIndex++)
            {
                var column = heatDTOs[heatIndex].Column;

                var localHeatIndex = heatIndex;
                mappers.Add(new ColumnMapper
                {
                    HeaderText = $"{column.Name} (Heat {heatIndex + 1})",
                    HeatIndex = heatIndex,
                    ColumnName = column.Name,
                    Formatter = pilot =>
                    {
                        var result = pilot.Results.FirstOrDefault(r => r.Name == column.Name && r.HeatIndex == localHeatIndex);
                        return result?.GetFormattedValue() ?? string.Empty;
                    },
                    Parser = (pilot, input) =>
                    {
                        var result = pilot.Results.FirstOrDefault(r => r.Name == column.Name && r.HeatIndex == localHeatIndex);
                        if (result != null)
                        {
                            result.SetValueFromString(input);
                        }
                    }
                });
            }
            return mappers;
        }
    }
}
