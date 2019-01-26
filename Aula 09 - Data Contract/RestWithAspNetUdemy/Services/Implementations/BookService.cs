using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RestWithAspNetUdemy.Model;
using RestWithAspNetUdemy.Model.Context;
using RestWithAspNetUdemy.Repository.Generic;
using RestWithAspNetUdemy.Repository;
using RestWithAspNetUdemy.Data.Converters;
using RestWithAspNetUdemy.Data.VO;

namespace RestWithAspNetUdemy.Services.Implementations
{
    public class BookService : IBookService
    {
        private IRepository<Book> _repository;

        private readonly BookConverter _converter;

        public BookService(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public BookVO Create(BookVO bookVO)
        {
            try
            {
                var book = _converter.Parse(bookVO);

                return _converter.Parse(_repository.Create(book));
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

        public List<BookVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public BookVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public BookVO Update(BookVO bookVO)
        {
            try
            {
                var book = _converter.Parse(bookVO);

                return _converter.Parse(_repository.Update(book));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
