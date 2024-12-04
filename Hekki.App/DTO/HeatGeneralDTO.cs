namespace Hekki.App.DTO
{
    public class HeatDTO
    {
        public HeatDTO(int heatIndex, List<HeatColumnViewModel> columns, int maxGroupCapacity, int groupsCount = 3)
        {
            HeatIndex = heatIndex;
            Columns = columns;
            MaxGroupCapacity = maxGroupCapacity;
            GroupsCount = groupsCount;
        }

        public int HeatIndex { get; }
        public int MaxGroupCapacity { get; }
        public int GroupsCount { get; }
        public List<HeatColumnViewModel> Columns { get; } = new();
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

