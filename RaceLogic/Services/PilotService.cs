using RaceLogic.Interfaces;
using RaceLogic.Models;

namespace RaceLogic.Services
{
    public class PilotService : IPilotService
    {
        public List<IPilot> CreatePilots(List<string> names)
        {
            var pilots = new List<IPilot>();
            
            foreach (var name in names)
            {
                pilots.Add(new Pilot(name));
            }
            
            return pilots;
        }

        public List<IPilot> CreatePilots(List<string> names, List<List<int>> kartsMerged, List<List<int>> scoresMerged, List<List<int>> timesMerged, List<string> liques)
        {
            var pilots = new List<IPilot>();
            for (int i = 0; i < names.Count; i++)
            {
                var karts = new List<int>();
                var scores = new List<int>();
                var times = new List<int>();

                if (kartsMerged.Count != 0)
                {
                    for (int j = 0; j < kartsMerged[i].Count; j++)
                    {
                        karts.Add(kartsMerged[i][j]);
                    }
                }
                if (timesMerged.Count != 0)
                {
                    for (int j = 0; j < timesMerged[i].Count; j++)
                    {
                        times.Add(timesMerged[i][j]);
                    }
                }
                if (scoresMerged.Count != 0)
                {
                    for (int j = 0; j < scoresMerged[i].Count; j++)
                    {
                        scores.Add(scoresMerged[i][j]);
                    }
                }
                if (liques.Count != 0)
                {
                    pilots.Add(new Pilot(karts, names[i], scores, times, liques[i]));
                }
                else
                {
                    pilots.Add(new Pilot(karts, names[i], scores, times));
                }
            }
            return pilots;
        }

        public void AddKarts(List<IPilot> pilots, List<int> karts)
        {
            CheckEquality(pilots.Count, karts.Count);

            for (int i = 0; i < pilots.Count; i++)
            {
                pilots[i].AddNumberKart(karts[i]);
            }
        }

        public void AddKarts(List<List<IPilot>> pilots, List<List<int>> karts)
        {
            CheckEquality(pilots.Count, karts.Count);

            for (int i = 0; i < pilots.Count; i++)
            {
                AddKarts(pilots[i], karts[i]);
            }
        }

        public void AddScores(List<IPilot> pilots, List<int> scores)
        {
            CheckEquality(pilots.Count, scores.Count);

            for (int i = 0; i < pilots.Count; i++)
            {
                pilots[i].AddScore(scores[i]);
            }
        }

        public void AddTimes(List<IPilot> pilots, List<int> times)
        {
            CheckEquality(pilots.Count, times.Count);

            for (int i = 0; i < pilots.Count; i++)
            {
                pilots[i].AddTime(times[i]);
            }
        }

        public List<List<string>> GetNames(List<List<IPilot>> pilots)
        {
            var names = new List<List<string>>();

            for (int i = 0; i < pilots.Count; i++)
            {
                names.Add(new List<string>());
                foreach (var pilot in pilots[i])
                {
                    names[i].Add(pilot.Name);
                }
            }

            return names;
        }

        private void CheckEquality(int count1, int count2)
        {
            if (count1 != count2)
            {
                throw new ArgumentException("Counts pilots and raceinfo is not same");
            }
        }
    }
}
