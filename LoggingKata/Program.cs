using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
 // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;
namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // DON'T FORGET TO LOG YOUR STEPS
            // Grab the path from the name of your file
            logger.LogInfo("Log initialized");
            // use File.ReadAllLines(path) to grab all the lines from your csv file
            var lines = File.ReadAllLines(csvPath);
            // Log and error if you get 0 lines and a warning if you get 1 line
            logger.LogInfo($"Lines: {lines[0]}");
            // Create a new instance of your TacoParser class
            var parser = new TacoParser();
            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();

            // Now, here's the new code

            // Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the furthest from each other.
            ITrackable tacoBell1 = null;
            ITrackable tacoBell2 = null;
            // Create a `double` variable to store the distance
            double distance = 0;
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`) (first for loop)
            // Create a new corA Coordinate with your locA's lat and long

            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`) (second for loop)
            // Create a new Coordinate with your locB's lat and long 
            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            GeoCoordinate corA = new GeoCoordinate();
            GeoCoordinate corB = new GeoCoordinate();

            var locA = new Tacobell();
            var locB = new Tacobell();

            for(int i = 0; i < locations.Length; i++)
            {
                corA.Latitude = locations[i].Location.Latitude;
                corA.Longitude = locations[i].Location.Longitude;            

                for(int j = 0; j < locations.Length; j++)
                {
                    corB.Latitude = locations[j].Location.Latitude;
                    corB.Longitude = locations[j].Location.Longitude;

                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);

                        locA.Name = locations[i].Name;
                        locB.Name = locations[j].Name;
                    }

                }
            }

            Console.WriteLine($"{locA.Name} and {locB.Name}");

            // Once you've looped through everything, you've found the two Taco Bells furthest away from each other.
            // TODO:  Find the two Taco Bells in Alabama that are the furthest from one another.
            // HINT:  You'll need two nested forloops
        }

    }
}