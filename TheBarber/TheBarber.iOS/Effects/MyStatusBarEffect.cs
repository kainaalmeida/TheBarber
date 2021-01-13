using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheBarber.Effects;
using TheBarber.iOS.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(MyStatusBarEffect), "StatusBarEffect")]
namespace TheBarber.iOS.Effects
{
    public class MyStatusBarEffect : PlatformEffect
    {
        public MyStatusBarEffect()
        {
        }

        protected override void OnAttached()
        {
            var frame = UIApplication.SharedApplication.KeyWindow?.WindowScene?.StatusBarManager.StatusBarFrame;
            if (frame.HasValue)
            {
                var statusBar = new UIView(frame.Value);
                statusBar.BackgroundColor = StatusBarEffect.GetBackgroundColor().ToUIColor();
                UIApplication.SharedApplication.StatusBarStyle = UIStatusBarStyle.LightContent;
                UIApplication.SharedApplication.KeyWindow?.AddSubview(statusBar);
            }
        }

        protected override void OnDetached()
        {
        }
    }
}