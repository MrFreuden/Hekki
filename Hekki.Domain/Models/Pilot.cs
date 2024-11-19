using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hekki.Domain.Models
{
    public class Pilot
    {
        private string _name;
        private string _ligue = "NoLique";
        private List<int> _scores = new();
        private List<int> _times = new();
        private List<int> _usedKarts = new();

        public Pilot(string name)
        {
            _name = name;
        }

        public Pilot(List<int> usedKarts, string name, List<int> scores, List<int> times)
            : this(name)
        {
            _usedKarts = usedKarts;
            _scores = scores;
            _times = times;
        }

        public Pilot(List<int> usedKarts, string name, List<int> scores, List<int> times, string lique)
            : this(usedKarts, name, scores, times)
        {
            _ligue = lique;
        }
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
