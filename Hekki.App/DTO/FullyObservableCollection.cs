using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Hekki.App.DTO
{
    public class FullyObservableCollection<T> : ObservableCollection<T> where T : INotifyPropertyChanged
    {
        public FullyObservableCollection()
        {
            CollectionChanged += FullyObservableCollectionCollectionChanged;
        }

        public FullyObservableCollection(IEnumerable<T> items) : base(items)
        {
            CollectionChanged += FullyObservableCollectionCollectionChanged;
            foreach (var item in items)
            {
                item.PropertyChanged += ItemPropertyChanged;
            }
        }

        private void FullyObservableCollectionCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (INotifyPropertyChanged item in e.OldItems)
                    item.PropertyChanged -= ItemPropertyChanged;
            }
            if (e.NewItems != null)
            {
                foreach (INotifyPropertyChanged item in e.NewItems)
                    item.PropertyChanged += ItemPropertyChanged;
            }
        }

        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var args = new NotifyCollectionChangedEventArgs(
                NotifyCollectionChangedAction.Replace,
                sender,
                sender,
                IndexOf((T)sender));
            OnCollectionChanged(args);
        }

        protected override void SetItem(int index, T item)
        {
            var oldItem = this[index];
            oldItem.PropertyChanged -= ItemPropertyChanged;
            base.SetItem(index, item);
            item.PropertyChanged += ItemPropertyChanged;
        }

        protected override void ClearItems()
        {
            foreach (var item in Items)
                item.PropertyChanged -= ItemPropertyChanged;
            base.ClearItems();
        }
    }
}
