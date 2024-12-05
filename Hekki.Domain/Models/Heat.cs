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
        public Heat()
        {

        }
        public Heat(int index, IResult resultType, int maxGroupCapacity, int groupsCount = 3)
        {
            Index = index;
            ResultType = resultType;
            MaxGroupCapacity = maxGroupCapacity;
            GroupsCount = groupsCount;
        }

        public int Index { get; }
        public IResult ResultType { get; }
        public int MaxGroupCapacity { get; }
        public int GroupsCount { get; }
    }

    public class Group
    {
       
    }
}
