using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelController.Interfaces
{
    public interface IExcelReader
    {
        List<string> ReadDataInColumn(int startRow, int column, int count);
        string ReadDataInCell(int startRow, int column);
    }
}
