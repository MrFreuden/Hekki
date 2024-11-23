using Hekki.Domain.Interfaces;

namespace Hekki.Domain.Models
{
    public class Pilot
    {
        private string _name;
        private readonly List<IResult> _results = new();
        private readonly List<int> _usedKarts = new();

        public Pilot(string name)
        {
            _name = name;
        }

        public string Name { get => _name; }
        public IReadOnlyList<IResult> Results { get => _results; }
        public IReadOnlyList<int> UsedKarts { get => _usedKarts; }

        public void AddResult(IResult result)
        {
            _results.Add(result);
        }

        public void AddUsedKart(int kartNumber)
        {
            _usedKarts.Add(kartNumber);
        }
    }
}
