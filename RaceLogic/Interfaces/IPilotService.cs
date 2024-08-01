﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceLogic.Interfaces
{
    public interface IPilotService
    {
        void AddKarts(List<List<IPilot>> pilots, List<List<int>> karts);
        void AddKarts(List<IPilot> pilots, List<int> karts);
        void AddScores(List<IPilot> pilots, List<int> scores);
        void AddTimes(List<IPilot> pilots, List<int> times);
        List<List<string>> GetNames(List<List<IPilot>> pilots);
    }
}
