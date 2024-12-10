namespace Hekki.App.DTO
{
    public class HeatDTO
    {
        public HeatDTO(int heatIndex, HeatColumnViewModel column, int maxGroupCapacity, int groupsCount = 3)
        {
            HeatIndex = heatIndex;
            Column = column;
            MaxGroupCapacity = maxGroupCapacity;
            GroupsCount = groupsCount;
        }

        public int HeatIndex { get; }
        public int MaxGroupCapacity { get; }
        public int GroupsCount { get; }
        public HeatColumnViewModel Column { get; }
    }
    
    public class HeatColumnViewModel
    {
        public HeatColumnViewModel(string name, Type dataType)
        {
            Name = name;
            DataType = dataType;
        }

        public string Name { get; }
        public Type DataType { get; }
    }
}

