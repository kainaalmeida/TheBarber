using TheBarber.Interfaces;
using TheBarber.iOS.Interfaces;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(StatusBarStyle))]
namespace TheBarber.iOS.Interfaces
{
    class StatusBarStyle : IStatusBarStyle
    {
        public void ChangeTextColor(bool darkContent = false)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var currentUIViewController = GetCurrentViewController();
                UIApplication.SharedApplication.SetStatusBarStyle(darkContent ? UIStatusBarStyle.LightContent : UIStatusBarStyle.DarkContent, false);
                currentUIViewController.SetNeedsStatusBarAppearanceUpdate();
            });
        }

        UIViewController GetCurrentViewController()
        {
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;
            while (vc.PresentedViewController != null)
                vc = vc.PresentedViewController;
            return vc;
        }
    }
}