using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelController.Interfaces
{
    public interface IExcelWriter
    {
        void WriteDataInColumn<T>(List<T> data, int column, int row);
        void AppendDataInColumn<T>(List<T> data, int column, int row);
    }
}
