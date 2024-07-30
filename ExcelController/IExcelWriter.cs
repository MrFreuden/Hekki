using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelController
{
    public interface IExcelWriter
    {
        int GroupAmount { get; set; }
        void WriteNamesInBoard(List<string> names);
        void WriteLiquesInBoard(List<string> liques);
        void WriteUsedKartsInBoard(List<List<int>> karts);
        void WriteTimesInBoard(List<List<int>> times);
        void WriteScoresInBoard(List<List<int>> scores);
        void WriteNamesInRace(List<string> names);
        void WriteUsedKartsInRace(List<List<int>> karts);
    }
}
