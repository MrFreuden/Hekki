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
        void SortBoardByTime();
        void SortBoardByScore();
        void TransferScoresToBoard();
        void TransferTimesToBoard();
        void ClearAll();
        void RebuildAll();
        void SetSortMethod(ISortMethod sortMethod);
        void SetDevideMethod(IDevideMethod devideMethod);
    }
}
