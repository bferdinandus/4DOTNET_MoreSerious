using Entities;
using Fakes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonBuilder pFakes = new PersonBuilder();
            List<Person> people = pFakes.Generate(1000);

            //linq alle personen waarvan de voor en achternaam met een M beginnen

            var q1 = from p in people
                     where p.FirstName.StartsWith("m", StringComparison.OrdinalIgnoreCase)
                     && p.LastName.StartsWith("m", StringComparison.OrdinalIgnoreCase)
                     select p;

            //q1.ToList().ForEach(p => Console.WriteLine(p));

            // linq alleen achernaam en leeftijd

            var q2 = from p in people
                     select new { p.LastName, p.Age, p.Car.Model, p.Car.Type, p.Car.Manufacturer };
            q2.ToList().ForEach(p => Console.WriteLine($"{p.LastName} ({p.Age}) rides a {p.Manufacturer} {p.Model} ({p.Type})"));



        }
    }
}
