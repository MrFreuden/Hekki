using Hekki.Domain.Interfaces;

namespace Hekki.Domain.Models
{
    public class Pilot
    {
        private string _name;
        private IResult _results;
        private List<int> _usedKarts = new();

        public Pilot(string name)
        {
            _name = name;
        }

        
    }

    
}
