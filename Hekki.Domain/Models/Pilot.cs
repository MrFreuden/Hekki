using Hekki.Domain.Interfaces;

namespace Hekki.Domain.Models
{
    public class Pilot
    {
        private string _name;
        private List<IResult> _results = new();
        private List<Kart> _usedKarts = new();
        private Guid _guid;

        public Pilot(string name)
        {
            _name = name;
            _guid = Guid.NewGuid();
        }

        public Guid Id
        {
            get => _guid;
            set => _guid = value;
        }

        public string Name 
        { 
            get => _name; 
            set => _name = value; 
        }

        public List<IResult> Results 
        { 
            get => _results; 
            set => _results = value;
        }

        public List<Kart> UsedKarts 
        { 
            get => _usedKarts; 
            set => _usedKarts = new List<Kart>(value);
        }

        public void AddResult(IResult result)
        {
            _results.Add(result);
        }

        public void AddUsedKart(int kartNumber)
        {
            _usedKarts.Add(new Kart(kartNumber));
        }
    }
}
