using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace DiagnosticUWPApp.View
{
    public class IsManualControl2BrushConverter : IValueConverter
    {
        readonly private static SolidColorBrush gray = new SolidColorBrush(Colors.LightGray);
        readonly private static SolidColorBrush red = new SolidColorBrush(Colors.Red);
        readonly private static SolidColorBrush[] brushes = new[] { gray, red };

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return brushes[(int)value];
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}