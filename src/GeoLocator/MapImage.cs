using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace DotNetLearningLab.GeoLocator
{
    sealed class MapImage
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task ShowAsync(Geocoordinate coordinate)
        {
            var lat = coordinate.Point.Position.Latitude;
            var lon = coordinate.Point.Position.Longitude;
            var accuracy = coordinate.Accuracy;

            string filename = string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:00.000},{1:00.000},{2:0000}m.jpg", lat, lon, accuracy);
            
            // Sanitize filename
            filename = filename.Replace("/", "_").Replace(":", "_");
            
            // Use Temp path to avoid Access Denied errors
            string tempPath = Path.GetTempPath();
            string fullPath = Path.Combine(tempPath, filename);

            Console.WriteLine($"Downloading map to {fullPath}...");
            await DownloadMapImageAsync(BuildURI(lat, lon, accuracy), fullPath);

            OpenWithDefaultApp(fullPath);
        }

        private static async Task DownloadMapImageAsync(Uri target, string filename)
        {
            try 
            {
                var data = await _httpClient.GetByteArrayAsync(target);
                await File.WriteAllBytesAsync(filename, data);
                Console.WriteLine("Download complete.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error downloading map: {ex.Message}");
            }
        }

        /// <summary>
        /// Map Image REST API by HERE Location Services
        /// </summary>
        /// <remarks>
        /// https://developer.here.com/
        /// </remarks>

        private static Uri BuildURI(double lat, double lon, double accuracy) 
        {
            // Replaced deprecated HERE Maps API with placeholder service
            // This demonstrates network functionality without requiring new API keys
            string text = string.Format(System.Globalization.CultureInfo.InvariantCulture, "Lat: {0:F3}\nLon: {1:F3}\nAcc: {2:F0}m", lat, lon, accuracy);
            string encodedText = Uri.EscapeDataString(text);
            
            return new Uri($"https://placehold.co/600x400/png?text={encodedText}");
        }

        private static void OpenWithDefaultApp(string filename)
        {
            try
            {
                var si = new ProcessStartInfo()
                {
                    FileName = filename,
                    UseShellExecute = true
                };
                Process.Start(si);
            }
            catch (Exception ex)
            {
                 Console.WriteLine($"Could not open file: {ex.Message}");
            }
        }
    }
}
