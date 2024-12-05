using Hekki.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hekki.App
{
    public class HeatService
    {
        public List<Heat> Make(Regulation regulation)
        {
            var list = new List<Heat>();
            for (int i = 0; i < regulation.HeatCount; i++)
            {
                list.Add( new Heat(i, regulation.HeatResults[i], regulation.MaxGroupCapacity));
            }
            return list;
        }
    }
}
