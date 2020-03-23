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
                    // Throw away the header
                    _ = reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        var result = ReefSurveyTest.Parsetest(line);

                        // Check for existing region
                        var region = db.Regions.Where(a => a.RegionName == result[0])
                                               .SingleOrDefault();

                        // Add region if none existed
                        if (region == null)
                        {
                            // Set Region contents from the CSV row
                            var newRegion = new Region() { RegionName = result[0] };

                            db.Add(newRegion);
                            db.SaveChanges(); // Never forget to save changes

                            // Single here (no default) as the row is known to exist at this point if an exception was not thrown by SaveChanges
                            region = db.Regions.Where(a => a.RegionName == result[0]).Single();

                            Console.WriteLine($"Added region {region.RegionName} with Id {region.RegionId}"); // Should see this one time
                        }

                        Console.WriteLine($"Region {region.RegionName} has Id {region.RegionId}"); // Should see this every time
                    }
                }
            }
        }
    }
}