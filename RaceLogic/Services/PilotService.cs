using RaceLogic.Interfaces;

namespace RaceLogic.Services
{
    public class PilotService : IPilotService
    {
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
