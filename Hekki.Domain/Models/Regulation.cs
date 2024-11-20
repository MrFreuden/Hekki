using Hekki.Domain.Interfaces;

namespace Hekki.Domain.Models
{
    public abstract class Regulation
    {
        public int HeatCount { get; protected set; }
        protected List<Func<Pilots, Pilots>> _sortMethods;
        protected List<IHeatResult> _heatResults;

        public IReadOnlyList<Func<Pilots, Pilots>> SortMethods { get { return _sortMethods; } }
        public IReadOnlyList<IHeatResult> HeatResults { get { return _heatResults; } }
        public int MaxGroupCapacity { get; protected set; } = 10;
        
    }

    public class TestRegulation : Regulation
    {
        public TestRegulation(int heatCount, List<IHeatResult> heatResults, List<Func<Pilots, Pilots>> sortMethods)
        {
            HeatCount = heatCount;
            _sortMethods = sortMethods;
            _heatResults = heatResults;
        }
    }
}