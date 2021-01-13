using Prism.Commands;
using Prism.Navigation;
using System.Threading.Tasks;
using TheBarber.Models;

namespace TheBarber.ViewModels
{
    public class DetailPageViewModel : ViewModelBase
    {
        private Barbers barber;
        public Barbers Barber
        {
            get { return barber; }
            set { SetProperty(ref barber, value); }
        }

        public DelegateCommand CloseCommand { get; set; }
        public DetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            CloseCommand = new DelegateCommand(async () => await ExecuteCloseCommand());
        }

        private async Task ExecuteCloseCommand()
        {
            await NavigationService.GoBackAsync();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Barber = parameters.GetValue<Barbers>(nameof(Barber));
        }
    }
}
