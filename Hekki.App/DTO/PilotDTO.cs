﻿using Hekki.Domain.Interfaces;
using Hekki.Domain.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Hekki.App.DTO
{
    public class PilotDTO : INotifyPropertyChanged
    {
        private string _name;
        private ObservableCollection<Kart> _usedKarts;
        private ObservableCollection<IResult> _results;
        private Guid _guid;

        public PilotDTO(string name, List<Kart> usedKarts, List<IResult> results, Guid id)
        {
            Name = name;
            UsedKarts = new ObservableCollection<Kart>(usedKarts);
            Results = new ObservableCollection<IResult>(results);
            _guid = id;

        }
        public PilotDTO(string name)
        {
            _name = name;
            _usedKarts = new ObservableCollection<Kart>();
            _results = new ObservableCollection<IResult>();
        }

        public PilotDTO()
        {
            _name = string.Empty;
            _usedKarts = new ObservableCollection<Kart>();
            _results = new ObservableCollection<IResult>();
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
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public ObservableCollection<Kart> UsedKarts
        {
            get => _usedKarts;
            set
            {
                if (_usedKarts != value)
                {
                    if (_usedKarts != null)
                        UnsubscribeFromResults(_usedKarts);

                    _usedKarts = value;

                    if (_usedKarts != null)
                        SubscribeToResults(_usedKarts);

                    OnPropertyChanged(nameof(Results));
                }
            }
        }

        public ObservableCollection<IResult> Results
        {
            get => _results;
            set
            {
                if (_results != value)
                {
                    if (_results != null)
                        UnsubscribeFromResults(_results);

                    _results = value;

                    if (_results != null)
                        SubscribeToResults(_results);

                    OnPropertyChanged(nameof(Results));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged; 
        private void SubscribeToResults<T>(ObservableCollection<T> results)
        {
            foreach (var result in results)
            {
                if (result is INotifyPropertyChanged notifyResult)
                    notifyResult.PropertyChanged += OnResultPropertyChanged;
            }

            results.CollectionChanged += OnResultsCollectionChanged;
        }

        private void UnsubscribeFromResults<T>(ObservableCollection<T> results)
        {
            foreach (var result in results)
            {
                if (result is INotifyPropertyChanged notifyResult)
                    notifyResult.PropertyChanged -= OnResultPropertyChanged;
            }

            results.CollectionChanged -= OnResultsCollectionChanged;
        }

        private void OnResultsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (var item in e.OldItems)
                {
                    if (item is INotifyPropertyChanged notifyResult)
                        notifyResult.PropertyChanged -= OnResultPropertyChanged;
                }
            }

            if (e.NewItems != null)
            {
                foreach (var item in e.NewItems)
                {
                    if (item is INotifyPropertyChanged notifyResult)
                        notifyResult.PropertyChanged += OnResultPropertyChanged;
                }
            }

            OnPropertyChanged(nameof(Results));
        }
        private void OnResultPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Results));
        }
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

    public class PilotsDTO : ObservableCollection<PilotDTO>
    {
        public event EventHandler<PilotDTO> PilotAdded;

        public PilotsDTO()
        {

        }

        public PilotsDTO(IEnumerable<PilotDTO> pilots)
        {
            foreach (var pilot in pilots)
            {
                Add(pilot);
            }
        }

        protected override void InsertItem(int index, PilotDTO item)
        {
            base.InsertItem(index, item);

            PilotAdded?.Invoke(this, item);
        }

    }
}

