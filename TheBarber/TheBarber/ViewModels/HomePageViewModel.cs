using Acr.UserDialogs;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Threading.Tasks;
using TheBarber.Interfaces;
using TheBarber.Views;
using Xamarin.Forms;

namespace TheBarber.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        public DelegateCommand MainCommand { get; set; }
        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            MainCommand = new DelegateCommand(async () => await ExecuteMainCommand());
        }

        private async Task ExecuteMainCommand()
        {
            try
            {
                if (IsBusy) return;

                IsBusy = true;
                using (var Dialog = UserDialogs.Instance.Loading("", null, null, true, MaskType.Black))
                {
                    await NavigationService.NavigateAsync($"{nameof(MainPage)}");
                }
            }
            catch (Exception) { }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
