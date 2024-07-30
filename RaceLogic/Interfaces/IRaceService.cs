using ExcelController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceLogic.Interfaces
{
    public interface IRaceService
    {
        IExcelWorker ExcelWorker { get; }
        IExcelWriter ExcelWriter { get; }
        IExcelReader ExcelReader { get; }
        IExcelHelper ExcelHelper { get; }
        
        
        
    }
}
