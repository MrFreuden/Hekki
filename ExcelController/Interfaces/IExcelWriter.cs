using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelController.Interfaces
{
    public interface IExcelWriter
    {
        void WriteCell(int row, int column, string value);
    }
}
