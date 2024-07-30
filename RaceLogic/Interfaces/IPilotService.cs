using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceLogic.Interfaces
{
    public interface IPilotService
    {
        void AddKarts(List<List<IPilot>> pilots, List<List<int>> karts);
        void AddScores(List<List<IPilot>> pilots, List<List<int>> scores);
        void AddTimes(List<List<IPilot>> pilots, List<List<int>> times);
        List<string> GetNames(List<IPilot> pilots);
    }
}
