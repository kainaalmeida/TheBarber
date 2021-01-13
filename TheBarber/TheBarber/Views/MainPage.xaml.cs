
using System.Linq;
using TheBarber.Effects;
using TheBarber.Models;
using TheBarber.ViewModels;
using Xamarin.Forms;

namespace TheBarber.Views
{
    public partial class MainPage
    {
        private MainPageViewModel ViewModel => BindingContext as MainPageViewModel;
        public MainPage()
        {
            InitializeComponent();
            StatusBarEffect.SetBackgroundColor(Color.FromHex("232222"));
            this.Effects.Add(new StatusBarEffect());
        }

        private void CollectionView_SelectionChanged(object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Barbers barbers)
                if (ViewModel.SelectedItemCommand.CanExecute(barbers))
                    ViewModel.SelectedItemCommand.Execute(barbers);

            barbersCollection.SelectedItem = null;
        }
    }
}
