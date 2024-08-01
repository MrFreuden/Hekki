﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceLogic.Interfaces
{
    public interface IRegulation
    {
        void SetSortMethod(ISortMethod sortMethod);
        void SetDevideMethod(IDevideMethod devideMethod);
        List<List<int>> GetCombos(List<List<IPilot>> pilots, List<int> numbersOfKarts);
        void Sort(List<IPilot> pilots);
        List<List<IPilot>> Devide(List<IPilot> pilots, int groupAmount);
    }
}
