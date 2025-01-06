using Hekki.Domain.Interfaces;
using Hekki.Domain.Models;
using System.ComponentModel;

namespace Hekki.App.DTO
{
    public class PilotDTO : INotifyPropertyChanged
    {
        private string _name;
        private FullyObservableCollection<Kart> _usedKarts;
        private FullyObservableCollection<IResult> _results;

        public PilotDTO(string name, List<Kart> usedKarts, List<IResult> results, Guid id)
        {
            Name = name;
            UsedKarts = new FullyObservableCollection<Kart>(usedKarts);
            Results = new FullyObservableCollection<IResult>(results);
            Id = id;

        }
        public PilotDTO(string name)
        {
            _name = name;
            _usedKarts = new FullyObservableCollection<Kart>();
            _results = new FullyObservableCollection<IResult>();
        }

        public PilotDTO()
        {
            _name = string.Empty;
            _usedKarts = new FullyObservableCollection<Kart>();
            _results = new FullyObservableCollection<IResult>();

        }

        public Guid Id { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public FullyObservableCollection<Kart> UsedKarts
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

        public FullyObservableCollection<IResult> Results
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static List<PilotDTO> CreateEmptyDTOs(int count)
        {
            var list = new List<PilotDTO>();
            for (int i = 0; i < count; i++)
            {
                list.Add(new PilotDTO());
            }
            return list;
        }
    }

    public class PilotsDTO : FullyObservableCollection<PilotDTO>
    {
        private readonly Action<PilotDTO> _synchronizator;
        public event EventHandler<PilotDTO> PilotAdded;

        public PilotsDTO(Action<PilotDTO> sync)
        {
            _synchronizator = sync ?? throw new ArgumentNullException(nameof(sync));
        }

        public PilotsDTO(IEnumerable<PilotDTO> pilots, Action<PilotDTO> sync) : this(sync)
        {
            _synchronizator = sync ?? throw new ArgumentNullException(nameof(sync));
            foreach (var pilot in pilots)
            {
                SubscribeToResultChanges(pilot);
                SubscribeToUsedKartChanges(pilot);
            }
        }

        protected override void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.ItemPropertyChanged(sender, e);

            if (sender is PilotDTO pilot)
            {
                _synchronizator?.Invoke(pilot);
            }
        }

        private void SubscribeToResultChanges(PilotDTO pilot)
        {
            foreach (var result in pilot.Results)
            {
                result.PropertyChanged += (sender, args) =>
                {
                    _synchronizator?.Invoke(pilot);
                };
            }
        }

        private void SubscribeToUsedKartChanges(PilotDTO pilot)
        {
            foreach (var kart in pilot.UsedKarts)
            {
                kart.PropertyChanged += (sender, args) =>
                {
                    _synchronizator.Invoke(pilot);
                };
            }
        }
        protected override void InsertItem(int index, PilotDTO item)
        {
            base.InsertItem(index, item);
            PilotAdded?.Invoke(this, item);
            SubscribeToUsedKartChanges(item);
            SubscribeToResultChanges(item);
        }

        public void Add(PilotDTO pilot)
        {
            InsertItem(Count, pilot);
        }
    }
}

