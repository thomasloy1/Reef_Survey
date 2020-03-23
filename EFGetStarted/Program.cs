using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DanimalReefSurvey
{
    class Program
    {
        static void Main()
        {
            using (var db = new ReefContext())
            {
                using (var reader = new StreamReader(@"D:\Documents\Microsoft Class\Reef_Survey\external\survey\1-data\Fish Dump.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        var result = ReefSurveyTest.Parsetest(line);

                        Console.WriteLine(result);

                        // 1. Create objects for headers 

                        // region NewRegion = new region;

                        // newregion = result [i]

                    }
                }
            }
        }
    }
}