using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RestWithAspNetUdemy.Model;
using RestWithAspNetUdemy.Model.Context;
using RestWithAspNetUdemy.Repository.Generic;
using RestWithAspNetUdemy.Data.Converters;
using RestWithAspNetUdemy.Data.VO;

namespace RestWithAspNetUdemy.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private IRepository<Person> _repository;

        private readonly PersonConverter _converter;

        public PersonService(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public PersonVO Create(PersonVO personVO)
        {
            try
            {
                var person = _converter.Parse(personVO);
                person = _repository.Create(person);

                return _converter.Parse(person);
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

        public List<PersonVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public PersonVO Update(PersonVO personVO)
        {
            try
            {
                var person = _converter.Parse(personVO);
                person = _repository.Update(person);

                return _converter.Parse(person);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
