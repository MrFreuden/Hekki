using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceLogic.Interfaces
{
    public interface IDevideMethod
    {
        List<List<T>> Devide<T>(List<T> list, int count);
    }
}
