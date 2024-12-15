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
        public int Z_index { get; set; }

        public List<ColumnMapper> GenerateColumnMappers(List<HeatDTO> heatDTOs)
        {
            var mappers = new List<ColumnMapper>();

            mappers.Add(new ColumnMapper
            {
                HeaderText = "Used Karts",
                Formatter = pilot => string.Join(" ", pilot.UsedKarts?.Select(k => k.Value.ToString()) ?? Enumerable.Empty<string>()),
                Parser = (pilot, input) =>
                {
                    var newKarts = input.Split(' ')
                        .Select(kart => new Kart(int.TryParse(kart.Trim(), out var num) ? num : 0))
                        .ToList();
                    pilot.UsedKarts.Clear();
                    foreach (var kart in newKarts)
                    {
                        pilot.UsedKarts.Add(kart);
                    }
                },
                Z_index = 0
            });

            mappers.Add(new ColumnMapper
            {
                HeaderText = "Pilot Name",
                Formatter = pilot => pilot.Name,
                Parser = (pilot, input) => pilot.Name = input,
                Z_index = 1
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
                    },
                    Z_index = 2
                });
            }
            return mappers;
        }

        public List<ColumnMapper> HeatColumnMappers(HeatDTO heatDTO)
        {
            var mappers = new List<ColumnMapper>();

            mappers.Add(new ColumnMapper
            {
                HeaderText = "Kart",
                Formatter = pilot => (pilot.UsedKarts != null && heatDTO.HeatIndex < pilot.UsedKarts.Count)
                                ? pilot.UsedKarts[heatDTO.HeatIndex].ToString()
                                : string.Empty,
                Parser = (pilot, input) =>
                {
                    pilot.UsedKarts[heatDTO.HeatIndex].Value = int.TryParse(input, out var num) ? num : 0;
                },
                Z_index = 0
            });

            mappers.Add(new ColumnMapper
            {
                HeaderText = "Pilot",
                Formatter = pilot => pilot.Name,
                Parser = (pilot, input) => pilot.Name = input,
                Z_index = 1
            });


            mappers.Add(new ColumnMapper
            {
                HeaderText = $"{heatDTO.Column.Name}",
                HeatIndex = heatDTO.HeatIndex,
                ColumnName = heatDTO.Column.Name,
                Formatter = pilot =>
                {
                    var result = pilot.Results.FirstOrDefault(r => r.Name == heatDTO.Column.Name && r.HeatIndex == heatDTO.HeatIndex);
                    return result?.GetFormattedValue() ?? string.Empty;
                },
                Parser = (pilot, input) =>
                {
                    var result = pilot.Results.FirstOrDefault(r => r.Name == heatDTO.Column.Name && r.HeatIndex == heatDTO.HeatIndex);
                    if (result != null)
                    {
                        result.SetValueFromString(input);
                    }
                },
                Z_index = 2
            });


            return mappers;
        }
    }
}
