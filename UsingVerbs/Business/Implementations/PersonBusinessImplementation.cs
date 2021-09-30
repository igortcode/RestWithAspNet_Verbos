using System.Collections.Generic;
using System.Linq;
using UsingVerbs.Repository;
using UsingVerbs.Model;
using System;

namespace UsingVerbs.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;
        public PersonBusinessImplementation(IPersonRepository personRepository)
        {
            _repository = personRepository;
        }
        public Person Create(Person person)
        {
            try
            {
                return (_repository.Create(person));
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool Delete(long id)
        {
            if (_repository.Existes(id))
            {
                try
                {
                    _repository.Delete(id);
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return false;
            }

        }

        public List<Person> FindAll()
        {
            try
            {
                return _repository.FindAll();
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
                return _repository.FindById(id);
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
                if (_repository.Existes(person.Id))
                    return _repository.Update(person);
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
