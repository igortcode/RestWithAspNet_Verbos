using System;
using System.Collections.Generic;
using System.Linq;
using UsingVerbs.Data;
using UsingVerbs.Model;

namespace UsingVerbs.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository    
    {
        private readonly Data.Context _context;
        public PersonRepositoryImplementation(Data.Context context)
        {
            _context = context;
        }
        public Person Create(Person person)
        {
            try
            {
                _context.People.Add(person);
                _context.SaveChanges();
                return (_context.People.OrderBy(p => p.Id).Last());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(long id)
        {
            try
            {
                var pessoa = _context.People.Find(id);
                _context.People.Remove(pessoa);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Existes(long id)
        {
            try
            {
                return _context.People.Any(p => p.Id.Equals(id));
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public List<Person> FindAll()
        {
            try
            {
                List<Person> people = _context.People.ToList();
                return people;
            }
            catch (Exception)
            {
                throw;
            }
          
        }

        public Person FindById(long id)
        {
            try
            {
                return _context.People.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Person Update(Person person)
        {
            try
            {
                _context.People.Update(person);
                _context.SaveChanges();
                return _context.People.Find(person.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
