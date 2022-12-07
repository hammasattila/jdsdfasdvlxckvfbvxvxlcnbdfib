using System;
using System.Resources;
using DiagnosticUWPApp.Model;
using OxyPlot;
using OxyPlot.Series;

namespace DiagnosticUWPApp.ViewModel.UserControls
{
    public class RobotHistoricValuesUserControlViewModel : ObservableObject
    {
        public readonly int MAX_NUMBR_OF_DATAPOINT = 100;
        public PlotModel Model { get; private set; }
        private double _simulationStep = 0.0;
        public double SimulationStep
        {
            get => _simulationStep;
            internal set
            {
                _simulationStep = value;
                if(_simulationStep == 0.0)
                {
                    _velocity.Points.Clear();
                    this._velocity.Points.Add(new DataPoint(0, 0));
                }
                else
                {
                    this._velocity.Points.Add(new DataPoint(value, this.Velocity));
                }

                if (this._velocity.Points.Count > MAX_NUMBR_OF_DATAPOINT)
                {
                    this._velocity.Points.RemoveAt(0);
                }

                this.Model.InvalidatePlot(true);
            }
        }
        public double Velocity { get; internal set; }

        private LineSeries _velocity;

        public RobotHistoricValuesUserControlViewModel()
        {

            this.Model = new PlotModel
            {
                Title = "Historic values",
                TitlePadding = 32,
                LegendPosition = LegendPosition.TopRight,
                LegendBackground = OxyColors.White,
                LegendBorder = OxyColors.Black,
                LegendPadding = 10,
                Padding = new OxyThickness(64, 20, 64, 20)
            };

            this._velocity = new LineSeries
            {
                Title = "Velocity [m/s]",
                Color = OxyPlot.OxyColors.Red,
                StrokeThickness = 2,
                MarkerType = OxyPlot.MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyPlot.OxyColors.Red,
                MarkerStrokeThickness = 3
            };

            this.Model.Series.Add(_velocity);
        }
    }
}
