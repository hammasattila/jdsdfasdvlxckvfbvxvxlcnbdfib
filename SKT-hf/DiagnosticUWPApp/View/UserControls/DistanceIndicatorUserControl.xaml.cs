using DiagnosticUWPApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace DiagnosticUWPApp.View.UserControls
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

    public class DistanceValue2RightPointConverter : IValueConverter
    {
        readonly private static Point CLOSE = new Point(100, 90);
        readonly private static Point FAR = new Point(115, 5);

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double val = ((Double)value) * 0.5 + 0.5;
            return new Point(
                val * (FAR.X - CLOSE.X) + CLOSE.X,
                (1 - val) * (CLOSE.Y - FAR.Y) + FAR.Y
            );
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

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

    public sealed partial class DistanceIndicatorUserControl : UserControl
    {
        [Description("Angle of the distance sensor"), Category("Data")]
        public double SensorAngle { get; set; }

        [Description("Value of the distance sensor"), Category("Data")]
        public double SensorValue { get; set; } = 1.0;

        public DistanceIndicatorUserControl()
        {
            this.InitializeComponent();
        }
    }
}
