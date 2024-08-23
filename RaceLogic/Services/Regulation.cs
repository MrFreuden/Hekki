using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceLogic.Interfaces;

namespace RaceLogic.Services
{
    public class Regulation : IRegulation
    {
        private IDevideMethod _devideMethod;
        private ISortMethod _sortMethod;
        private ICombination _combination;

        public Regulation(IDevideMethod groupesDevider, ISortMethod sortMethod, ICombination combination)
        {
            _devideMethod = groupesDevider;
            _sortMethod = sortMethod;
            _combination = combination;
        }

        public List<List<IPilot>> Devide(List<IPilot> pilots, int groupAmount)
        {
            var q = _devideMethod.Devide(pilots, groupAmount);
            return q;
        }

        public void Sort(List<IPilot> pilots)
        {
            _sortMethod.Sort(pilots);
        }
        //TODO: Переделать метод. Не нравится что сюда передаются пилоты и метод взять карты.
        public List<List<int>> GetCombos(List<List<IPilot>> groupsPilots, List<int> numbersOfKarts)
        {
            var combos = new List<List<int>>();
            for (int i = 0; i < groupsPilots.Count; i++)
            {
                var usedKarts = GetUsedKartsFromGroup(groupsPilots[i]);
                var combo = _combination.GetCombo(usedKarts, numbersOfKarts);
                var selectedCombo = combo.Take(groupsPilots[i].Count).ToList();
                combos.Add(selectedCombo);
            }
            return combos;
        }

        private List<List<int>> GetUsedKartsFromGroup(List<IPilot> group)
        {
            var usedKarts = new List<List<int>>();
            for (int i = 0; i < group.Count; i++)
            {
                usedKarts.Add(group[i].GetNumbersKarts());
            }
            return usedKarts;
        }

        public void SetDevideMethod(IDevideMethod devideMethod)
        {
            _devideMethod = devideMethod;
        }

        public void SetSortMethod(ISortMethod sortMethod)
        {
            _sortMethod = sortMethod;
        }
    }
}
