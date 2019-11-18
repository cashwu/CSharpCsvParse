using System;
using System.Collections.Generic;
using System.Text;
using TinyCsvParser;
using TinyCsvParser.Mapping;
using TinyCsvParser.TypeConverter;

namespace testCsv
{
    internal class TinyCsvParse
    {
        public IEnumerable<Automobile> Parse()
        {
            var csvParserOptions = new CsvParserOptions(true, ',');
            var csvParser = new CsvParser<Automobile>(csvParserOptions, new CsvAutomobileMapping());

            var records = csvParser.ReadFromFile("sample.txt", Encoding.UTF8);
            
            foreach (var record in records)
            {
                if (record.IsValid)
                {
                    yield return record.Result;
                }
                else
                {
                    Console.WriteLine(record.Error);
                }
            }
        }

        class CsvAutomobileMapping : CsvMapping<Automobile>
        {
            public CsvAutomobileMapping()
            {
                MapProperty(0, a => a.Make);
                MapProperty(1, a => a.Model);
                MapProperty(2, a => a.Type, new EnumConverter<AutomobileType>());
                MapProperty(3, a => a.Year);
                MapProperty(4, a => a.Price);
                MapProperty(5, a => a.Comment, new AutumobileCommentTypeConverter());
            }
        }

        internal class AutumobileCommentTypeConverter : ITypeConverter<AutomobileComment>
        {
            public bool TryConvert(string value, out AutomobileComment result)
            {
                result = new AutomobileComment
                {
                    Comment = value
                };

                return true;
            }

            public Type TargetType => typeof(AutomobileComment);
        }
    }
}