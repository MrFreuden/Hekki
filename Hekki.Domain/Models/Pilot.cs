using Hekki.Domain.Interfaces;

namespace Hekki.Domain.Models
{
    public class Pilot
    {
        private string _name;
        private string _ligue = "NoLique";
        private IResult _results;
        private List<int> _usedKarts = new();

        public Pilot(string name)
        {
            _name = name;
        }

        public Pilot(List<int> usedKarts, string name)
            : this(name)
        {
            _usedKarts = usedKarts;
        }

        public Pilot(List<int> usedKarts, string name, string lique)
            : this(usedKarts, name)
        {
            _ligue = lique;
        }

        public string Name { get => _name; set => _name = value; }
        public IReadOnlyList<int> UsedKarts { get => _usedKarts; }
        public IResult Results { get { return _results; } }
    }

    public class Pilots : List<Pilot>
    {
        public void Add(string name)
        {
            Add(new Pilot(name));
        }

        public void SortByScore()
        {
            throw new NotImplementedException();
        }

        public void SortByTime()
        {
            throw new NotImplementedException();
        }
    }
}
