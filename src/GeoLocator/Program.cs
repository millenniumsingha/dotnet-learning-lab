using System;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace DotNetLearningLab.GeoLocator
{
    sealed class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting Geolocator (Windows.Devices.Geolocation)...");
            Console.WriteLine("Note: Location access must be enabled in Windows Settings.");

            try
            {
                var accessStatus = await Geolocator.RequestAccessAsync();
                
                if (accessStatus != GeolocationAccessStatus.Allowed)
                {
                    Console.WriteLine($"Access to location is denied. Status: {accessStatus}");
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                    return;
                }

                var geolocator = new Geolocator { DesiredAccuracyInMeters = 100 };

                Console.WriteLine("Getting current position...");
                
                // Get single position
                var pos = await geolocator.GetGeopositionAsync();
                
                Console.WriteLine($"Position found: {pos.Coordinate.Point.Position.Latitude}, {pos.Coordinate.Point.Position.Longitude}");
                Console.WriteLine($"Accuracy: {pos.Coordinate.Accuracy} meters");

                // Use the Map Image REST Api
                await MapImage.ShowAsync(pos.Coordinate);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            if (!Console.IsInputRedirected)
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
