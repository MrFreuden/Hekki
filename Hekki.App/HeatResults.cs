using Hekki.Domain.Interfaces;
using Hekki.Domain.Models;

namespace Hekki.App
{
    public class PointsResult : IResult
    {
        private int _value;
        public PointsResult(int heatIndex, int point = default)
        {
            _value = point;
            HeatIndex = heatIndex;
        }

        public string Name => "Points";

        public int HeatIndex { get; }

        public string GetFormattedValue()
        {
            return Convert.ToString(_value);
        }

        public void SetValueFromString(string value)
        {
            if (int.TryParse(value, out int result))
            {
                _value = result;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }

    public class TimesResult : IResult
    {
        private TimeSpan _value;
        public TimesResult(int heatIndex, TimeSpan time = default)
        {
            _value = time;
            HeatIndex = heatIndex;
        }

        public string Name => "Times";
        public int HeatIndex { get; }
        public string GetFormattedValue()
        {
            return _value.ToString();
        }

        public void SetValueFromString(string value)
        {
            if (TimeSpan.TryParse(value, out TimeSpan result))
            {
                _value = result;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
