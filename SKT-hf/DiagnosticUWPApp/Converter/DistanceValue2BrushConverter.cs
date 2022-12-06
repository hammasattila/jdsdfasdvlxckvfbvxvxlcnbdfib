using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace DiagnosticUWPApp.Converter
{
    public class DistanceValue2BrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double val = (Double)value;
            Color color = Color.FromArgb(
                a: (byte)((0.5 + (1 - val) / 2) * 0xFF),
                r: (byte)((1 - val) * 0xFF),
                g: (byte)((val) * 0xFF),
                b: 0
            );
            return new SolidColorBrush(color);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
