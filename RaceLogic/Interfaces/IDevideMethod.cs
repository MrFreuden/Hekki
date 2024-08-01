using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceLogic.Interfaces
{
    public interface IDevideMethod
    {
        IList<IList<T>> Devide<T>(IList<T> list, int count);
    }
}
