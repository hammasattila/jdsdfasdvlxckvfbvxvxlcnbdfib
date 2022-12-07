using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace DiagnosticUWPApp.View
{
    public class IsManualControl2BrushConverter : IValueConverter
    {
        readonly private static SolidColorBrush gray = new SolidColorBrush(Colors.LightGray);
        readonly private static SolidColorBrush blue = new SolidColorBrush(Colors.LightBlue);
        readonly private static SolidColorBrush[] brushes = new[] { gray, blue };

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if ((bool)value)
                return brushes[1];
            else
                return brushes[0];
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}