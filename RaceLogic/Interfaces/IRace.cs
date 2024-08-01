using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceLogic.Interfaces
{
    public interface IRace
    {
        ISortMethod SortMethod { get; }
        IDevideMethod DevideMethod { get; }
        void MakeHeat();
        void SortBoardByTime();
        void SortBoardByScore();
        void TransferScoresToBoard();
        void TransferTimesToBoard();
        void ClearAll();
        void RebuildAll();
    }
}
