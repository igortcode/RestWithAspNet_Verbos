using System.Collections.Generic;
using UsingVerbs.Model;

namespace UsingVerbs.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
        bool Existes(long id);
    
    }

}
