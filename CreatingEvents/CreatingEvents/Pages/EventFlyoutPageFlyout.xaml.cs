using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CreatingEvents.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventFlyoutPageFlyout : ContentPage
    {
        public ListView ListView;

        public EventFlyoutPageFlyout()
        {
            InitializeComponent();

            BindingContext = new EventFlyoutPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class EventFlyoutPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<EventFlyoutPageFlyoutMenuItem> MenuItems { get; set; }

            public EventFlyoutPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<EventFlyoutPageFlyoutMenuItem>(new[]
                {
                    new EventFlyoutPageFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new EventFlyoutPageFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new EventFlyoutPageFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new EventFlyoutPageFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new EventFlyoutPageFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}