using Acr.UserDialogs;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TheBarber.Effects;
using TheBarber.Models;
using TheBarber.Views;
using Xamarin.Forms;

namespace TheBarber.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<Barbers> Barbers { get; private set; }
        public ObservableCollection<BarberShops> BarberShops { get; private set; }

        private int selectedBarberId;
        public int SelectedBarberId
        {
            get { return selectedBarberId; }
            set { SetProperty(ref selectedBarberId, value); }
        }

        public DelegateCommand<Barbers> SelectedItemCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            StatusBarEffect.SetBackgroundColor(Color.FromHex("#232222"));
            SelectedItemCommand = new DelegateCommand<Barbers>(async (barber) => await ExecuteSelectedItemCommand(barber));

            LoadBarbers();
            LoadBarberShops();
        }

        private async Task ExecuteSelectedItemCommand(Barbers barber)
        {
            try
            {
                if (barber is null) return;

                if (IsBusy) return;

                SelectedBarberId = barber.Id;

                IsBusy = true;

                using (var Dialog = UserDialogs.Instance.Loading("", null, null, true, MaskType.Black))
                {
                    var navParams = new NavigationParameters();
                    navParams.Add("Barber", barber);
                    await NavigationService.NavigateAsync($"{nameof(DetailPage)}", navParams);
                }
            }
            catch (Exception) { }
            finally
            {
                IsBusy = false;
            }
        }
        void LoadBarbers()
        {
            Barbers = new ObservableCollection<Barbers>
            {
                new Barbers("Saîd","Marsa - Tunis", "barber01.png",1),
                new Barbers("Lasmer","Lac 2 - Tunis", "barber02.png",2),
                new Barbers("Ramzy","Web elil - Tunis", "barber03.png",3)
            };
        }

        void LoadBarberShops()
        {
            BarberShops = new ObservableCollection<BarberShops>
            {
                new BarberShops("The Gentlemen","Awina - Tunis", "barber_1.png",1),
                new BarberShops("Marwen & Co","Awina - Tunis", "barber_2.png",2),
                new BarberShops("New Look","Awina - Tunis", "barber_3.png",3),
                new BarberShops("Old Scholl","Awina - Tunis", "barber_4.png",4)
            };
        }

    }
}
