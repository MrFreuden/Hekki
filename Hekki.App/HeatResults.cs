using Hekki.Domain.Interfaces;
using Hekki.Domain.Models;

namespace Hekki.App
{
    public class PointsResult : IResult
    {
        public string Label => "Points";
    }

    public class TimesResult : IResult
    {
        public string Label => "Times";

    }
}
