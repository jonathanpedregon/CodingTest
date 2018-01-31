using System;
using System.Linq;
using System.IO;

namespace CityAlpabetizer
{
    public class CityConsolidator
    {
        private static string CAFilePath = "InputFiles/CACities.txt";
        private static string USFilePath = "InputFiles/USCities.txt";
        private static FileInfo CombinedFileInfo { get; set; }
        private string CombinedFilePath { get; set; }
        private int CALineCount;
        private int USLineCount;
        private string CACity { get; set; }
        private string USCity { get; set; }

        public void Extecute()
        {
            var TempFileDirectory = Path.GetTempPath();
            CombinedFilePath = Path.Combine(TempFileDirectory, "Combined.txt");
            //This is where the output file is place. The path will be written to the
            //console when the program is complete so it can be retrieved. Feel free to 
            //enter a different TempFileDirectory for easier access to the output.
            CombinedFileInfo = new FileInfo(CombinedFilePath); 
            CombinedFileInfo.CreateText().Close();
            CombineCities();
            Console.WriteLine($"The output file is located here: {CombinedFilePath}");
            Console.Read();
        }

        public void CombineCities()
        {
            do
            {
                SetCities();
                AppendToCombinedFile();
            }
            while (!string.IsNullOrEmpty(CACity) || !string.IsNullOrEmpty(USCity));
        }

        public void SetCities()
        {
            if (CALineCount >= File.ReadAllLines(CAFilePath).Length)
                CACity = string.Empty;
            else
                CACity = File.ReadLines(CAFilePath).Skip(CALineCount).Take(1).First();
            if (USLineCount >= File.ReadAllLines(USFilePath).Length)
                USCity = string.Empty;
            else
                USCity = File.ReadLines(USFilePath).Skip(USLineCount).Take(1).First();
        }


        public void AppendToCombinedFile()
        {
            using (StreamWriter sw = CombinedFileInfo.AppendText())
            {
                if (!string.IsNullOrEmpty(CACity) && !string.IsNullOrEmpty(USCity))
                {

                    if (CACity.CompareTo(USCity) < 0)
                    {
                        sw.WriteLine(CACity);
                        CALineCount++;
                    }
                    else
                    {
                        sw.WriteLine(USCity);
                        USLineCount++;
                    }
                }
                else if (string.IsNullOrEmpty(CACity))
                {
                    sw.WriteLine(USCity);
                    USLineCount++;
                }
                else
                {
                    sw.WriteLine(CACity);
                    CALineCount++;
                }
            }
        }
    }
}

