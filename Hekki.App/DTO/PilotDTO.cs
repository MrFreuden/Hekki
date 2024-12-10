using Hekki.Domain.Interfaces;
using Hekki.Domain.Models;

namespace Hekki.App.DTO
{
    public class PilotDTO
    {
        private string _name;
        private Karts _usedKarts;
        private List<IResult> _results;
        private Guid _guid;

        public PilotDTO(string name, Karts usedKarts, List<IResult> results, Guid id)
        {
            Name = name;
            UsedKarts = usedKarts;
            Results = results;
            _guid = id;

        }

        public PilotDTO()
        {
            _name = string.Empty;
            _usedKarts = new Karts();
            _results = new List<IResult>();
        }

        public Guid Id
        {
            get
            {
                return _guid;
            }
            set
            {
                _guid = value;
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;

                }
            }
        }

        public Karts UsedKarts
        {
            get => _usedKarts;
            set
            {
                if (_usedKarts != value)
                {
                    _usedKarts = value;

                }
            }
        }

        public List<IResult> Results
        {
            get => _results;
            set
            {
                if (_results != value)
                {
                    _results = value;

                }
            }
        }


    }
}

