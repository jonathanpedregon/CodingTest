namespace CityAlpabetizer
{
    class Program
    {
        static void Main(string[] args)
        {
            //The two input files have been placed inside the project.
            var consolidator = new CityConsolidator();
            consolidator.Extecute();
        }
    }
}
