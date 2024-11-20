using Hekki.Domain.Interfaces;
using Hekki.Domain.Models;

namespace Hekki.App
{
    public class PointsResult : IResult<int>
    {
        private List<int> _points;
        public IReadOnlyList<int> Points { get { return _points; } }
        public string GetLabel() => "Points";

        public void PopulateRow(Dictionary<string, int> row, int heatIndex)
        {
            throw new NotImplementedException();
        }
    }

    public class TimesResult : IResult<DateTime>
    {
        public DateTime Times { get; }

        public TimesResult(DateTime times)
        {
            Times = times;
        }
        public string GetResultAsString()
        {
            return Times.ToString();
        }

        public string GetLabel()
        {
            throw new NotImplementedException();
        }

        public void PopulateRow(Dictionary<string, DateTime> row, int heatIndex)
        {
            throw new NotImplementedException();
        }

        public string Label => "Times";
    }

    public class PointsAndTimesResult : IResult<T> 
    {
        public string GetLabel()
        {
            throw new NotImplementedException();
        }

        public void PopulateRow(Dictionary<string, (int, DateTime)> row, int heatIndex)
        {
            throw new NotImplementedException();
        }
    }
}
