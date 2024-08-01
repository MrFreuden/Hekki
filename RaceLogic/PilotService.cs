using Microsoft.Office.Interop.Excel;
using RaceLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceLogic
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

        private void CheckEquality(int count1, int count2)
        {
            if (count1 != count2)
            {
                throw new ArgumentException("Counts pilots and raceinfo is not same");
            }
        }
    }
}
