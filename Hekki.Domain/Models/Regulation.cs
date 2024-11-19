namespace Hekki.Domain.Models
{
    public abstract class Regulation
    {
        protected int _heatCount;
        protected List<Func<Pilots, Pilots>> _sortMethods;

        //protected Combination _combinationMethod;
    }

    public class TestRegulation : Regulation
    {
        public TestRegulation(int heatCount, List<Func<Pilots, Pilots>> sortMethods)
        {
            _heatCount = heatCount;
            _sortMethods = sortMethods;
            //_combinationMethod = combination;
        }
    }
}