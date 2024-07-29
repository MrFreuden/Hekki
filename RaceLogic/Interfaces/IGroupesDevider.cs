using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceLogic.Interfaces
{
    public interface IGroupesDevider
    {
        List<List<Pilot>> DivideByGroup(int groupSize);
        List<List<Pilot>> SimpleDivideByGroup(int groupSize);
    }
}
