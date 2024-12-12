using Hekki.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hekki.Domain.Interfaces
{
    public interface IResult : INotifyPropertyChanged
    {
        string GetFormattedValue(); 
        void SetValueFromString(string value);
        string Name { get; }
        int HeatIndex { get; }
    }
}
