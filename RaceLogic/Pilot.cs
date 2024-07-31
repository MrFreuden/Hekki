using RaceLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceLogic
{
    public class Pilot : IPilot
    {
        private string _name;
        private string _ligue = "NoLique";
        private List<int> _scores = new();
        private List<int> _times = new();
        private List<int> _usedKarts = new();

        public string Name => _name;
        public string Lique => _ligue;
        public int SumScores => _scores.Sum();
        public int SumTimes => throw new NotImplementedException();

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

        public void AddNumberKart(int numberKart)
        {
            _usedKarts.Add(numberKart);
        }

        public void AddScore(int score)
        {
            _scores.Add(score);
        }

        public void AddTime(int time)
        {
            _times.Add(time);
        }

        public string GetAllNumbersKartsAsString()
        {
            string res = "";
            foreach (int numberKart in _usedKarts)
            {
                res += numberKart.ToString() + " ";
            }
            return res;
        }

        public int GetNumberKartByRace(int numberRace)
        {
            return _usedKarts[numberRace];
        }
    }
}
