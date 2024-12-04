using Hekki.Domain.Interfaces;

namespace Hekki.App.DTO
{
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
}

