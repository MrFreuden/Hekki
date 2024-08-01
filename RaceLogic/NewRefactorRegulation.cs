using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceLogic.Interfaces;

namespace RaceLogic
{
    public class NewRefactorRegulation : IRegulation
    {
        private IGroupesDevider _groupesDevider;
        private ISortMethod _sortMethod;

        public NewRefactorRegulation(IGroupesDevider groupesDevider)
        {
            _groupesDevider = groupesDevider;
        }

        public List<List<IPilot>> Devide(int groupAmount)
        {
            throw new NotImplementedException();
        }

        public List<List<int>> GetCombos(List<List<IPilot>> pilots)
        {
            throw new NotImplementedException();
        }

        public void SetDevideMethod(IDevideMethod devideMethod)
        {
            throw new NotImplementedException();
        }

        public void SetSortMethod(ISortMethod sortMethod)
        {
            throw new NotImplementedException();
        }

        public void Sort(List<IPilot> pilots)
        {
            throw new NotImplementedException();
        }
    }
}
