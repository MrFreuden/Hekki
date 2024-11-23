using Hekki.Domain.Interfaces;

namespace Hekki.Domain.Models
{
    public abstract class Regulation
    {
        protected List<Func<List<Pilot>, List<Pilot>>> _sortMethods;
        protected List<IResult> _heatResults;

        public int HeatCount { get; protected set; }
        public IReadOnlyList<Func<List<Pilot>, List<Pilot>>> SortMethods { get { return _sortMethods; } }
        public IReadOnlyList<IResult> HeatResults { get { return _heatResults; } }
        public int MaxGroupCapacity { get; protected set; } = 10;
        
    }

    public class TestRegulation : Regulation
    {
        public TestRegulation(int heatCount, List<IResult> heatResults, List<Func<List<Pilot>, List<Pilot>>> sortMethods)
        {
            HeatCount = heatCount;
            _sortMethods = sortMethods;
            _heatResults = heatResults;
        }
    }
}