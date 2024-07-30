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
        List<List<int>> ReadUsedKartsInBoard();
        List<List<int>> ReadTimesInBoard();
        List<List<int>> ReadScoresInBoard();
        List<List<int>> ReadUsedKartsInRace();
        List<List<string>> ReadNamesInRace();
        List<List<int>> ReadScoresInRace();
        List<List<int>> ReadTimesInRace();
    }
}
