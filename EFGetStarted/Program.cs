using System;
using System.Linq;

namespace EFGetStarted
{
    class Program
    {
        static void Main()
        {
            using (var db = new ReefContext())
            {
                // Create
                Console.WriteLine("Inserting a new blog");
                db.Add(new Region { RegionName = "http://blogs.msdn.com/adonet" });
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for a blog");
                var blog = db.Region
                    .OrderBy(b => b.RegionId)
                    .First();

                // Update
                Console.WriteLine("Updating the blog and adding a post");
                blog.RegionName = "https://devblogs.microsoft.com/dotnet";
                blog.Posts.Add(
                    new SubRegion
                    {
                        SubRegionName = "Hello World",
                        Content = "I wrote an app using EF Core!"
                    });
                db.SaveChanges();

                // Delete
                Console.WriteLine("Delete the blog");
                db.Remove(blog);
                db.SaveChanges();
            }
        }
    }
}