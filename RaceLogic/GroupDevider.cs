using RaceLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceLogic
{
    public class GroupDevider : IGroupesDevider
    {
        public List<List<IPilot>> DivideByGroup(List<IPilot> pilots, int groupSize)
        {
            var groups = new List<List<IPilot>>();
            int countGroups = (int)Math.Ceiling((double)pilots.Count / groupSize);

            for (int i = 0; i < countGroups; i++)
                groups.Add(new List<IPilot>());

            for (int i = 0, j = 0; i < pilots.Count; i++, j++)
            {
                if (j == countGroups)
                    j = 0;
                groups[j].Add(pilots[i]);
            }
            return groups;
        }

        public List<List<IPilot>> SimpleDivideByGroup(List<IPilot> pilots, int groupSize)
        {
            var dividedGroups = DivideByGroup(pilots, groupSize);
            var groups = new List<List<IPilot>>();
            int countGroups = (int)Math.Ceiling((double)pilots.Count / groupSize);

            for (int i = 0; i < countGroups; i++)
                groups.Add(new List<IPilot>());

            int counter = 0;
            for (int i = 0, j = 0; i < countGroups; i++)
            {
                while (counter < dividedGroups[i].Count)
                {
                    groups[i].Add(pilots[j]);
                    j++;
                    counter++;
                }
                counter = 0;
            }
            return groups;
        }
    }
}
