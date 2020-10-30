using Entities;
using Bogus;
using System.Linq;

namespace Fakes
{
    public class PersonBuilder : Faker<Entities.Person>
    {
        public PersonBuilder(string locale = "en") : base(locale)
        {
            StrictMode(true);
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.FirstName, f => f.Name.FirstName());
            RuleFor(p => p.LastName, f => f.Name.LastName());
            RuleFor(p => p.Age, f => f.Random.Int(1, 123));
            //RuleFor(p => p.Car, f => new VehicleBuilder().Generate(1).First() );
        }
    }
}
