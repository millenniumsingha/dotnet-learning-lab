using System;
using System.Diagnostics;

namespace DotNetLearningLab.WeatherTrend.Models
{
    public struct WeatherObservation
    {
        public DateTime Timestamp { get; set; }
        public float BarometricPressure { get; set; }

        public static WeatherObservation Parse(string text)
        {
            var data = text.Split('\t');

            Debug.Assert(data.Length == 8);

            var timestamp = DateTime.Parse(data[(int)WeatherObservationMetrics.DateTime].Replace("_", "-"), System.Globalization.CultureInfo.InvariantCulture);
            var pressure = float.Parse(data[(int)WeatherObservationMetrics.BarometricPressure], System.Globalization.CultureInfo.InvariantCulture);

            return new WeatherObservation()
            {
                Timestamp = timestamp,
                BarometricPressure = pressure
            };
        }

        public static bool TryParse(string text, out WeatherObservation wo)
        {
            wo = new WeatherObservation()
            {
                Timestamp = DateTime.MinValue,
                BarometricPressure = float.NaN
            };

            var data = text.Split('\t');

            if (data.Length != 8)
                return false;

            if (!DateTime.TryParse(data[(int)WeatherObservationMetrics.DateTime].Replace("_", "-"), System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime timeStamp))
                return false;

            if (!float.TryParse(data[(int)WeatherObservationMetrics.BarometricPressure], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out float pressure))
                return false;

            wo = new WeatherObservation()
            {
                Timestamp = timeStamp,
                BarometricPressure = pressure
            };
            return true;
        }
    }
}
