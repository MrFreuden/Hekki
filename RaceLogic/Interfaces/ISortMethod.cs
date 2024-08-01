using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceLogic.Interfaces
{
    public interface ISortMethod
    {
        IList<T> Sort<T>(IList<T> list);
    }
}
