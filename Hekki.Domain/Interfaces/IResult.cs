using Hekki.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hekki.Domain.Interfaces
{
    public interface IResult
    {
        public string Value { get; set; }
        public string Label { get; }
    }
}
