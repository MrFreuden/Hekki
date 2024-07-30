using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceLogic.Interfaces;

namespace RaceLogic
{// Взаимодействуем с пилотами
    public class NewRefactorRegulation : IRegulation
    {
        private IGroupesDevider _groupesDevider;

        public NewRefactorRegulation(IGroupesDevider groupesDevider)
        {
            _groupesDevider = groupesDevider;
        }

        private int Test { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void AddScores(List<int> scores)
        {
            throw new NotImplementedException();
        }

        public void RemoveScores(List<int> scores)
        {
            throw new NotImplementedException();
        }

        public void SortByScore(List<IPilot> pilots)
        {
            throw new NotImplementedException();
        }

        public void SortByTime(List<IPilot> pilots)
        {
            throw new NotImplementedException();
        }

        public void SortRandom(List<IPilot> pilots)
        {
            throw new NotImplementedException();
        }
    }
}
