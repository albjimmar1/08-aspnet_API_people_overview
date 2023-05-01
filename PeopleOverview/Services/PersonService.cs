using PeopleOverview.Models;

namespace PeopleOverview.Services;

public static class PersonService
{
    static List<Person> People { get; }
    static int nextId = 3;
    static PersonService()
    {
        People = new List<Person>
        {
            new Person { 
                Id = 1, 
                Name = "Alberto", 
                Surnames = "Jiménez Marín", 
                Age = 26, 
                CountryOfBirth = "Spain", 
                CountryOfResidence = "Spain", 
                //Job = false , 
                //IsSatisfiedWithWork = false, 
                //GrossAnnualSalary = false, 
                //Currency = false, 
                //IsSatisfiedWithSalary = false 
            },
            new Person { 
                Id = 1, 
                Name = "Elon", 
                Surnames = "Reeve Musk", 
                Age = 51, 
                CountryOfBirth = "South Africa", 
                CountryOfResidence = "United States", 
                Job = "Entrepreneur" , 
                IsSatisfiedWithWork = true, 
                GrossAnnualSalary = 1000000, 
                Currency = "Dollar", 
                IsSatisfiedWithSalary = false 
            }
        };
    }

    public static List<Person> GetAll() => People;

    public static Person? Get(int id) => People.FirstOrDefault(p => p.Id == id);

    public static void Add(Person person)
    {
        person.Id = nextId++;
        People.Add(person);
    }

    public static void Delete(int id)
    {
        var person = Get(id);
        if(person is null)
            return;

        People.Remove(person);
    }

    public static void Update(Person person)
    {
        var index = People.FindIndex(p => p.Id == person.Id);
        if(index == -1)
            return;

        People[index] = person;
    }
}