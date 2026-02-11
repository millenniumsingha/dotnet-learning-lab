using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace DotNetLearningLab.GeoLocator
{
    class MapImage
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task ShowAsync(Geocoordinate coordinate)
        {
            var lat = coordinate.Point.Position.Latitude;
            var lon = coordinate.Point.Position.Longitude;
            var accuracy = coordinate.Accuracy;

            string filename = $"{lat:00.000},{lon:00.000},{accuracy:0000}m.jpg";
            
            // Sanitize filename
            filename = filename.Replace("/", "_").Replace(":", "_");

            Console.WriteLine($"Downloading map to {filename}...");
            await DownloadMapImageAsync(BuildURI(lat, lon, accuracy), filename);

            OpenWithDefaultApp(filename);
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
            #region HERE App ID & App Code
            string HereApi_AppID = "BpJ4qijas6smWHBJFCXo";
            string HereApi_AppCode = "6Io4_d8-h9D2WSuinBfhjA";
            #endregion

            var HereApi_DNS = "image.maps.cit.api.here.com";
            var HereApi_URL = $"https://{HereApi_DNS}/mia/1.6/mapview";
            var HereApi_Secrets = $"&app_id={HereApi_AppID}&app_code={HereApi_AppCode}";

            var latlon = $"&lat={lat}&lon={lon}";

            // Use invariant culture for formatting coords in URI
            return new Uri(HereApi_URL + $"?u={accuracy}" + HereApi_Secrets + latlon);
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
