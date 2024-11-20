using Hekki.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hekki.Domain.Interfaces
{
    public interface IResult<T> where T : IComparable
    {
        string GetLabel();
        void PopulateRow(Dictionary<string, T> row, int heatIndex);
    }
}
