using Hekki.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hekki.App
{
    public class PointsResult : IHeatResult
    {
        public string Label => "Points";
    }

    public class TimesResult : IHeatResult
    {
        public string Label => "Times";
    }

    public class PointsAndTimesResult : IHeatResult
    {
        public string Label => "???";
    }
}
