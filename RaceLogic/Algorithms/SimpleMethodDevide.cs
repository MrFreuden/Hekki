using RaceLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceLogic.Algorithms
{
    public class SimpleMethodDevide : IDevideMethod
    {
        private int _countKarts;
        private int _maxKarts;

        public SimpleMethodDevide(int countKarts, int maxKarts)
        {
            _countKarts = countKarts;
            _maxKarts = maxKarts;
        }

        public IList<IList<T>> Devide<T>(IList<T> list, int count)
        {
            var groups = new List<IList<T>>();

            for (int i = 0; i < count; i++)
                groups.Add(new List<T>());

            var groupSizes = CalculateGroupSizes(list.Count, count, _maxKarts, _countKarts);
            int index = 0;
            foreach (var data in list)
            {
                groups[index].Add(data);
                if (groups[index].Count == groupSizes[index])
                {
                    index++;
                }
            }

            return groups;
        }

        private List<int> CalculateGroupSizes(int totalPilots, int groupCount, int maxGroupSize, int availableKarts)
        {
            var groupSizes = new List<int>();
            int effectiveGroupCount = Math.Min(groupCount, availableKarts);
            int baseSize = totalPilots / effectiveGroupCount;
            int remainder = totalPilots % effectiveGroupCount;

            for (int i = 0; i < effectiveGroupCount; i++)
            {
                int size = baseSize;
                if (remainder > 0)
                {
                    size++;
                    remainder--;
                }
                groupSizes.Add(Math.Min(size, maxGroupSize));
            }

            return groupSizes;
        }
    }
}
