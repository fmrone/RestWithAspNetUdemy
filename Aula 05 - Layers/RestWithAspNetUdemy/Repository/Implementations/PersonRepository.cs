using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RestWithAspNetUdemy.Model;
using RestWithAspNetUdemy.Model.Context;

namespace RestWithAspNetUdemy.Repository.Implementations
{
    public class PersonRepository : IPersonRepository
    {
        private MySqlContext _context;

        public PersonRepository(MySqlContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();

                return person;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(long id)
        {
            var _person = _context.Persons.SingleOrDefault(q => q.Id == id);
            
            try
            {
                if (_person == null)
                    _context.Persons.Remove(_person);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(q => q.Id == id);
        }

        public Person Update(Person person)
        {
            var _person = _context.Persons.SingleOrDefault(q => q.Id == person.Id);
            if (_person == null)
                return new Person();

            try
            {
                _context.Entry(_person).CurrentValues.SetValues(person);
                _context.SaveChanges();

                return person;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
