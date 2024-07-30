using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceLogic.Interfaces
{
    public interface IPilot
    {
        string Name { get; }
        string Lique { get; }
        int Score { get; }
        List<int> Scores { get; }
        List<int> Times { get; }
        List<int> UsedKarts { get; }
        void AddNumberKart(int numberKart);
        int GetNumberKartByRace(int numberRace);
        string GetAllNumbersKartsAsString();
        void AddScore(int score);
        void AddTime(int time);
    }
}
