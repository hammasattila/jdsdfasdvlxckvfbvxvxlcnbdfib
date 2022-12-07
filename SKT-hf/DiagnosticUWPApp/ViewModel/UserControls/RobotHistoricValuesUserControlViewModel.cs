using System;
using DiagnosticUWPApp.Model;
using OxyPlot;
using OxyPlot.Series;

namespace DiagnosticUWPApp.ViewModel.UserControls
{
    public class RobotHistoricValuesUserControlViewModel : ObservableObject
    {
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

                this.Model.InvalidatePlot(true);
            }
        }
        public double Velocity { get; internal set; }

        private LineSeries _velocity;

        public RobotHistoricValuesUserControlViewModel()
        {

            this.Model = new PlotModel
            {
                Title = "Speed"
            };

            this._velocity = new LineSeries
            {
                Title = "Velocity [m/s]",
                Color = OxyPlot.OxyColors.Red,
                StrokeThickness = 1,
                MarkerSize = 5,
                MarkerType = OxyPlot.MarkerType.Circle

            };

            this.Model.Series.Add(_velocity);
        }
    }
}
