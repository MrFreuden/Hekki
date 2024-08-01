using RaceLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceLogic
{
    public class SortMethod : ISortMethod
    {
        public IList<T> Sort<T>(IList<T> list)
        {
            return list;
        }
    }
}
