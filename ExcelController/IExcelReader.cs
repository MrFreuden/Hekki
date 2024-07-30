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
        List<List<int>> ReadColTimesInBoard(int countRows);
        List<List<int>> ReadColScoresInBoard(int countRows);
        List<List<int>> ReadUsedKartsInRace();
        List<List<string>> ReadNamesInRace();
        List<int> ReadColScoresInRace(int countRows, int startRow);
        List<int> ReadColTimesInRace(int countRows, int startRow);
    }
}
