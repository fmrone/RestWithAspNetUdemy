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
    public class BookService : IBookService
    {
        private IRepository<Book> _repository;

        public BookService(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public Book Create(Book book)
        {
            try
            {
                return _repository.Create(book);
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

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Book Update(Book book)
        {
            try
            {
                return _repository.Update(book);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
