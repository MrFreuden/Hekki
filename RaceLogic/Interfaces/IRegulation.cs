using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceLogic.Interfaces
{
    public interface IRegulation
    {
        void SortBy(ISortByResult);
        void SortFor(ISortForRace);
    }
}
