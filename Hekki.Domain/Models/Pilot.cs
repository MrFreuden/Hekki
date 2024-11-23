using Hekki.Domain.Interfaces;

namespace Hekki.Domain.Models
{
    public class Pilot
    {
        private string _name;
        private List<IResult> _results;
        private List<int> _usedKarts = new();

        public Pilot(string name)
        {
            Name = name;
        }

        public string Name { get => _name; set => _name = value; }
        public IReadOnlyList<IResult> Results { get => _results; }
        public IReadOnlyList<int> UsedKarts { get => _usedKarts; }
    }
}
