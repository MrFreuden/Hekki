using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Hekki.Domain.Models
{
    public class Kart : INotifyPropertyChanged
    {
        private int _value;

        public Kart()
        {

        }

        public Kart(int value)
        {
            Value = value;
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


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}
