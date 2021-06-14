using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; }
        public MainPage() { InitializeComponent(); ViewModel = new MainViewModel(); }

        private void SearchTicketBooks_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ViewModel != null)
            {
                if (string.IsNullOrWhiteSpace(SearchTicketBooksBox.Text))
                {
                    ViewModel.TicketBooks.Filter = _ => true;
                }
                else
                {
                    ViewModel.TicketBooks.Filter = x => ((TicketBookDto)x).StartNumber == SearchTicketBooksBox.Text;
                    //{
                    //    var startNumber = Convert.ToInt32(((TicketBookDto)x).StartNumber);
                    //    var endNumber = Convert.ToInt32(((TicketBookDto)x).EndNumber);
                    //    var searchText = Convert.ToInt32(SearchTicketBooksBox.Text);
                    //    return searchText >= startNumber && searchText <= endNumber;
                    //};
                }
            }
        }

        private void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ViewModel.TicketBooks.Add(new TicketBookDto { StartNumber = "123", EndNumber = "456" });
            ViewModel.TicketBooks.Add(new TicketBookDto { StartNumber = "789", EndNumber = "987" });
        }
    }
}
