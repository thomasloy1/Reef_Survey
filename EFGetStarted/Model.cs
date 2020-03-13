using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DanimalReefSurvey
{
    public class ReefContext : DbContext
    {
        public DbSet<Region> Regions { get; set; }
        public DbSet<SubRegion> SubRegions { get; set; }

        public DbSet<StudyArea> StudyAreas { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Survey> Surveys { get; set; }

        public DbSet<Batch> Batchs { get; set; }

        public DbSet<Index> Indexes { get; set; }

        public DbSet<Fish> Fishes { get; set; }

        public DbSet<Name> FishNames { get; set; }

        public DbSet<Characteristic> FishCharacteristics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FishDump;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    }

    public class Region
    {
        public int RegionId { get; set; }
        public string RegionName { get; set; }

    }

    public class SubRegion
    {
        public int SubRegionId { get; set; }
        public string SubRegionName { get; set; }
        
        public Region Region { get; set; }

        public int RegionId { get; set; }
    }

    public class StudyArea
    {
        public int StudyAreaId { get; set; }

        public string StudyAreaName { get; set; }

        public SubRegion SubRegion { get; set; }

        public int SubRegionId { get; set; }
    }

    public class Location
    {
        public int LocationId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public StudyArea StudyArea { get; set; }

        public int StudyAreaId { get; set; }
    }

    public class Survey
    {
        public int SurveyId { get; set; }

        public string Date { get; set; }

        public Region Region { get; set; }

        public int RegionId { get; set; }
    }

    public class Batch
    {
        public int BatchId { get; set; }

        public string BatchCode { get; set; }

        public Survey Survey { get; set; }

        public int SurveyId { get; set; }
    }

    public class Index
    {
        public int IndexId { get; set; }

        public string IndexNum { get; set; }

        public Batch Batch { get; set; }

        public int BatchId { get; set; }
    }

    public class Fish
    {
        public int FishId { get; set; }

        public Survey Survey { get; set; }

        public int SurveyId { get; set; }
    }

    public class Name
    {
        public int NameId { get; set; }

        public string Family { get; set; }

        public string ScientificName { get; set; }

        public string CommonName { get; set; }

        public Fish Fish { get; set; }

        public int FishId { get; set; }
    }

    public class Characteristic
    {
        public int CharacteristicId { get; set; }

        public string Trophic { get; set; }

        public double Length { get; set; }

        public int Count { get; set; }

        public string Structure { get; set; }

        public Name Name { get; set; }

        public int NameId { get; set; }
    }
}