namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");
            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                logger.LogError("Array length is less than 3.");
                return null;
                // Log that and return null
            }

            var latitude = double.Parse(cells[0]);
            var longtitude = double.Parse(cells[1]);
            var name = cells[2];

            var tacoBell = new Tacobell();
            var point = new Point();

            point.Longitude = longtitude;
            point.Latitude = latitude;

            tacoBell.Location = point;
            tacoBell.Name = name;

            return tacoBell;
        }
    }
}