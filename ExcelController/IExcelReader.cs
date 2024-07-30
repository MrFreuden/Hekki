using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelController
{
    public interface IExcelReader
    {
        List<string> ReadNamesInBoard();
        List<string> ReadLiquesInBoard();
        List<List<string>> ReadUsedKartsInBoard();
        List<List<string>> ReadTimesInBoard();
        List<List<string>> ReadScoresInBoard();
        List<List<string>> ReadUsedKartsInRace();
        List<List<string>> ReadNamesInRace();
        List<List<string>> ReadScoresInRace();
        List<List<string>> ReadTimesInRace();
    }
}
