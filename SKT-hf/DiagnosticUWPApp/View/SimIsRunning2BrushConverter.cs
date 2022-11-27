using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace DiagnosticUWPApp.View
{
    public class SimIsRunning2BrushConverter : IValueConverter
    {
        readonly private static SolidColorBrush green = new SolidColorBrush(Colors.Green);
        readonly private static SolidColorBrush red = new SolidColorBrush(Colors.Red);
        readonly private static SolidColorBrush[] brushes = new[] { green, red };

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