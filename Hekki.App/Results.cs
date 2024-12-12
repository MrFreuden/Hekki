using Hekki.Domain.Interfaces;
using Hekki.Domain.Models;
using System.ComponentModel;

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

        public int Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    OnPropertyChanged(nameof(Value));
                }
            }
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
                Value = result;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

        public TimeSpan Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    OnPropertyChanged(nameof(Value));
                }
            }
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
                Value = result;
            }
            else
            {
                throw new ArgumentException();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
