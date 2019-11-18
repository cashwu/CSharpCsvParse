using System;

namespace testCsv
{
    class Program
    {
        static void Main(string[] args)
        {
            var csvHelperParse = new CsvHelperParse();

            foreach (var automobile in csvHelperParse.Parse())
            {
                Console.WriteLine(automobile); 
            }
            
            var tinyCsvParse = new TinyCsvParse();

            foreach (var automobile in tinyCsvParse.Parse())
            {
                Console.WriteLine(automobile); 
            }
        }
    }
}