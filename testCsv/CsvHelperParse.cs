using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;

namespace testCsv
{
    internal class CsvHelperParse
    {
        public IEnumerable<Automobile> Parse()
        {
            using TextReader reader = new StreamReader("sample.txt");

            var csvReader = new CsvReader(reader);
            var records = csvReader.GetRecords<Automobile>();

            foreach (var record in records)
            {
                yield return record;
            }
        }
    }
}