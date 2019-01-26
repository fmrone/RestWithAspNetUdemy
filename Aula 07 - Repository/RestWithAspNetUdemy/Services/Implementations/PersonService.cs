using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RestWithAspNetUdemy.Model;
using RestWithAspNetUdemy.Model.Context;
using RestWithAspNetUdemy.Repository.Generic;
using RestWithAspNetUdemy.Repository;

namespace RestWithAspNetUdemy.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private IRepository<Person> _repository;

        public PersonService(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public Person Create(Person person)
        {
            try
            {
                return _repository.Create(person);
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
                _repository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Person Update(Person person)
        {
            try
            {
                return _repository.Update(person);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
