using Hekki.Domain.Interfaces;
using Hekki.Domain.Models;

namespace Hekki.App
{
    public class PointsResult : IResult
    {
        public string Value {  get; set; }
        public PointsResult(int point)
        {
            Value = Convert.ToString(point);
        }
        public string Label => "Points";
    }

    public class TimesResult : IResult
    {
        public string Value { get; set; }
        public TimesResult(TimeSpan time)
        {
            Value = time.ToString();
        }
        public string Label => "Times";

    }
}
