using ExcelController;
using RaceLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceLogic
{
    public class RaceService : IRaceService
    {
        private IExcelHelper _excelHelper;
        private IExcelReader _excelReader;
        private IExcelWriter _excelWriter;
        private IExcelWorker _excelWorker;

        public IExcelWorker ExcelWorker => _excelWorker;

        public IExcelWriter ExcelWriter => _excelWriter;

        public IExcelReader ExcelReader => _excelReader;

        public IExcelHelper ExcelHelper => _excelHelper;

        public RaceService(IExcelHelper excelHelper, IExcelReader excelReader, IExcelWriter excelWriter, IExcelWorker excelWorker) 
        { 
            _excelHelper = excelHelper;
            _excelReader = excelReader;
            _excelWriter = excelWriter;
            _excelWorker = excelWorker;
        }

        
    }
}
