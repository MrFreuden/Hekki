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
        void AddNumberKart(int numberKart);
        int GetNumberKartByRace(int numberRace);
        string GetAllNumbersKartsAsString();
        void AddScore(int score);
        void AddTime(int time);
        List<int> GetNumbersKarts();
    }
}
