using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

using DotNetLearningLab.WeatherTrend.Models;

namespace DotNetLearningLab.WeatherTrend
{
    public partial class MainWindow : Window, System.ComponentModel.INotifyPropertyChanged
    {
        // Use Environment.ProcessPath to resolve the actual .exe location on disk
        // AppContext.BaseDirectory points to the temp extraction folder in single-file builds
        private static string filename = Path.Combine(
            Path.GetDirectoryName(Environment.ProcessPath)!,
            "pond_data",
            "Environmental_Data_Deep_Moor_2012.txt");

        private ISeries[] _series = Array.Empty<ISeries>();
        private Axis[] _xAxes = Array.Empty<Axis>();
        private Axis[] _yAxes = Array.Empty<Axis>();

        public ISeries[] Series 
        { 
            get => _series; 
            set { _series = value; OnPropertyChanged(); } 
        }
        
        public Axis[] XAxes 
        { 
            get => _xAxes; 
            set { _xAxes = value; OnPropertyChanged(); } 
        }
        
        public Axis[] YAxes 
        { 
            get => _yAxes; 
            set { _yAxes = value; OnPropertyChanged(); } 
        }

        public event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(name));
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            if (!File.Exists(filename))
            {
                MessageBox.Show($"Data file not found at:\n{filename}\n\nPlease ensure 'pond_data' directory exists next to the executable.", "Missing Data", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            // ChartValues of WeatherObservation
            var values = new ObservableCollection<WeatherObservation>();
            LoadData(values);

            // Add LineSeries
            Series = new ISeries[]
            {
                new LineSeries<WeatherObservation>
                {
                    Name = "Barometric Pressure",
                    Values = values,
                    Mapping = (wo, index) => 
                    {
                         return new(wo.Timestamp.Ticks, (double)wo.BarometricPressure);
                    },
                    Fill = null,
                    GeometrySize = 0,
                    Stroke = new SolidColorPaint(SKColors.DodgerBlue) { StrokeThickness = 2 }
                }
            };
            
            XAxes = new Axis[]
            {
                new Axis
                {
                    Labeler = value => new DateTime((long)value).ToString("yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture)
                }
            };

            YAxes = new Axis[]
            {
                new Axis
                {
                    Labeler = value => value.ToString("###.00", System.Globalization.CultureInfo.InvariantCulture)
                }
            };
        }

        private static void LoadData(ObservableCollection<WeatherObservation> values)
        {
            var start = DateTime.Parse("2012-01-02 00:00:00", System.Globalization.CultureInfo.InvariantCulture);
            var end = DateTime.Parse("2012-01-02 17:00:00", System.Globalization.CultureInfo.InvariantCulture);

            using (var text = new StreamReader(filename))
            {
                text.ReadLine();

                var woValues = WeatherData.ReadRange(text, start, end);

                foreach(var wo in woValues)
                {
                    values.Add(wo);
                }
            }
        }
    }
}
