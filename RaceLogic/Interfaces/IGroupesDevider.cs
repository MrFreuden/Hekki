using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceLogic.Interfaces
{
    public interface IGroupesDevider
    {
        List<List<IPilot>> DivideByGroup(List<IPilot> pilots, int groupSize);
        List<List<IPilot>> SimpleDivideByGroup(List<IPilot> pilots, int groupSize);
    }
}
