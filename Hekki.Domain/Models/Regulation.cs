using Hekki.Domain.Interfaces;

namespace Hekki.Domain.Models
{
    public abstract class Regulation
    {
        public int HeatCount { get; protected set; }
        protected List<Func<Pilots, Pilots>> _sortMethods;
        protected List<IResult> _heatResults;

        public IReadOnlyList<Func<Pilots, Pilots>> SortMethods { get { return _sortMethods; } }
        public IReadOnlyList<IResult> HeatResults { get { return _heatResults; } }
        public int MaxGroupCapacity { get; protected set; } = 10;
        
    }

    public class TestRegulation : Regulation
    {
        public TestRegulation(int heatCount, List<IResult> heatResults, List<Func<Pilots, Pilots>> sortMethods)
        {
            HeatCount = heatCount;
            _sortMethods = sortMethods;
            _heatResults = heatResults;
        }
    }
}