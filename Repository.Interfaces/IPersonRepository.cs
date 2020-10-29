using Entities;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Interfaces
{
    public interface IPersonRepository
    {
        IQueryable<Person> Get();
        void Insert(Person person);
        bool Update(Person person);
        bool Delete(int id);

        bool Save(); // Optioneel

    }
}
