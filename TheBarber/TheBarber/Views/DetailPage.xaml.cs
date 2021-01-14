using System;
using TheBarber.Effects;
using Xamarin.Forms;

namespace TheBarber.Views
{
    public partial class DetailPage : ContentPage
    {
        double oldY = 230;
        double smoothFactor = 0.25;

        double minPan = 230;
        double maxPan = 550;

        public DetailPage()
        {
            InitializeComponent();
            this.Effects.Add(new StatusBarEffect());
        }

        private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            var y = e.TotalY;
            y = smoothFactor * (y - oldY);

            var height = detail.HeightRequest + -1 * y;
            height = Math.Max(Math.Min(height, maxPan), minPan);

            detail.HeightRequest = height;
            oldY = y;

            //if (e.StatusType == GestureStatus.Completed || e.StatusType == GestureStatus.Canceled)
            //{
            //    var toUpper = Math.Abs(maxPan - height);
            //    var toBottom = Math.Abs(minPan - height);

            //    if (toUpper > toBottom)
            //        detail.HeightRequest = maxPan;
            //    else
            //        detail.HeightRequest = minPan;
            //}
        }
    }
}
