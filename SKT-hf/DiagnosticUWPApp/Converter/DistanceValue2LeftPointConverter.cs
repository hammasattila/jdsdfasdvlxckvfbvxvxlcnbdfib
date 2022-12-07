using System;
using Windows.Foundation;
using Windows.UI.Xaml.Data;

namespace DiagnosticUWPApp.Converter
{
    public class DistanceValue2LeftPointConverter : IValueConverter
    {
        readonly private static Point CLOSE = new Point(100, 90);
        readonly private static Point FAR = new Point(85, 5);

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double val = ((Double)value) * 0.5 + 0.5;
            return new Point(
                (1 - val) * (CLOSE.X - FAR.X) + FAR.X,
                (1 - val) * (CLOSE.Y - FAR.Y) + FAR.Y
            );
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
