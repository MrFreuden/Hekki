using Hekki.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hekki.Domain.Models
{
    public class Heat
    {
        private IResult _heatResult;
        private Func<Pilots, Pilots> _sortFunc;

        private List<Group> _groups;
        private Pilots _avaiblePilots;
        public IResult HeatResult { get { return _heatResult; } }
        public int GroupCapacity { get; set; }
        public int GroupCount => _groups.Count;

        public Heat(Func<Pilots, Pilots> sortFunc, IResult heatResult)
        {
            _sortFunc = sortFunc;
        }

        public void AddPilots(Pilots pilots)
        {
            _avaiblePilots = pilots;
        }

        public void DistributeByGroups(int groupCount, int maxGroupCapacity, List<int> groupsCapacity)
        {
            _groups = new List<Group>(groupCount);

        }
    }

    public class Group
    {
        public int Capacity { get; set; }
        public int Count => _pilotsInGroup.Count;
        private List<Pilot> _pilotsInGroup;

        public void AddPilot(Pilot pilot)
        {
            if (Count == Capacity)
            {
                throw new InvalidOperationException("Превышена вместимость");
            }

            _pilotsInGroup.Add(pilot);
        }
    }
}
