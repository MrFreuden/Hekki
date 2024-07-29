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

        public RaceService(IExcelHelper excelHelper, IExcelReader excelReader, IExcelWriter excelWriter, IExcelWorker excelWorker) 
        { 
            _excelHelper = excelHelper;
            _excelReader = excelReader;
            _excelWriter = excelWriter;
            _excelWorker = excelWorker;
        }

        public List<string> ReadNamesInBoard()
        {
            throw new NotImplementedException();
        }

        public List<string> ReadNamesInRace()
        {
            throw new NotImplementedException();
        }

        public List<int> ReadScoresInRace()
        {
            throw new NotImplementedException();
        }

        public List<string> ReadTimeInRace()
        {
            throw new NotImplementedException();
        }

        public void WriteNamesInRace()
        {
            throw new NotImplementedException();
        }

        public void WriteScoreInBoard()
        {
            throw new NotImplementedException();
        }

        public void WriteTimeInBoard()
        {
            throw new NotImplementedException();
        }

        public void WriteUsedKartsInBoard()
        {
            throw new NotImplementedException();
        }

        public void WriteUsedKartsInRace()
        {
            throw new NotImplementedException();
        }
    }
}
