using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceLogic.Interfaces
{
    public interface ICombination
    {
        List<int> GetCombo(List<List<int>> usedKarts, List<int> numberKarts);
    }
}
