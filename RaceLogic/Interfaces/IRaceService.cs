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
        void WriteScoreInBoard();
        void WriteTimeInBoard();
        void WriteUsedKartsInBoard();
        void WriteUsedKartsInRace();
        void WriteNamesInRace();
        List<string> ReadNamesInRace();
        List<int> ReadScoresInRace();
        List<string> ReadTimeInRace();
        List<string> ReadNamesInBoard();
    }
}
