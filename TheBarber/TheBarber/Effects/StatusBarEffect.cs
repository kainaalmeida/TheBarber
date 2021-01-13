using Xamarin.Forms;

namespace TheBarber.Effects
{
    public class StatusBarEffect : RoutingEffect
    {
        private static Color BackgroundColor;
        public static void SetBackgroundColor(Color color)
        {
            BackgroundColor = color;
        }
        public static Color GetBackgroundColor()
        {
            return BackgroundColor;
        }

        public StatusBarEffect() : base("Xamarin.StatusBarEffect")
        { }
    }
}