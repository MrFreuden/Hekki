using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceLogic.Interfaces
{
    public interface IRace
    {
        void MakeHeat();
        void SortPilots();
        void SortTimes();
        void SortScores();
        void TransferScoresToBoard();
        void TransferTimesToBoard();
    }
}
