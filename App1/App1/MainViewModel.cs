using Microsoft.Toolkit.Uwp.UI;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace App1
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ObservableCollection<TicketBookDto> _ticketBooksPrivate = new ObservableCollection<TicketBookDto>();
        private AdvancedCollectionView ticketBooks;
        public AdvancedCollectionView TicketBooks
        {
            get
            {
                if (ticketBooks is null)
                {
                    ticketBooks = new AdvancedCollectionView(_ticketBooksPrivate, true);
                    ticketBooks.ObserveFilterProperty(nameof(TicketBookDto.StartNumber));
                    ticketBooks.ObserveFilterProperty(nameof(TicketBookDto.EndNumber));
                }
                return ticketBooks;
            }
            set => Set(ref ticketBooks, value);
        }

        #region INotifyStuff
        public event PropertyChangedEventHandler PropertyChanged;
        protected void Set<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion
    }
}
