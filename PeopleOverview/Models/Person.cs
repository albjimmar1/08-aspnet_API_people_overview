 using Microsoft.EntityFrameworkCore;

namespace PeopleOverview.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surnames { get; set; }
        public int? Age { get; set; }
        public string? CountryOfBirth { get; set; }
        public string? CountryOfResidence { get; set; }
        public string? Job { get; set; }
        public bool? IsSatisfiedWithWork { get; set; }
        public decimal? GrossAnnualSalary { get; set; }
        public string? Currency { get; set; } 
        public bool? IsSatisfiedWithSalary { get; set; }
    }
    class PersonDb : DbContext
    {
        public PersonDb(DbContextOptions options) : base(options) { }
        public DbSet<Person> People { get; set; } = null!;
    }
}