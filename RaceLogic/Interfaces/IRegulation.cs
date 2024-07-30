using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceLogic.Interfaces
{
    public interface IRegulation
    {
        List<List<int>> GetCombos(List<List<IPilot>> pilots);
        void Sort(List<IPilot> pilots, ISortMethod sortMethod);
        List<List<IPilot>> Devide(IDevideMethod devideMethod, int groupAmount);
    }
}
