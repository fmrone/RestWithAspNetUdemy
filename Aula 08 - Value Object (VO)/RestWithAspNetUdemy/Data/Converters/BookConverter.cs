using RestWithAspNetUdemy.Data.Converter;
using RestWithAspNetUdemy.Data.VO;
using RestWithAspNetUdemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNetUdemy.Data.Converters
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public Book Parse(BookVO origin)
        {
            if (origin == null)
                return new Book();

            return new Book
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price
            };
        }

        public List<Book> ParseList(List<BookVO> origin)
        {
            if (origin == null)
                return new List<Book>();

            return origin.Select(item => Parse(item)).ToList();
        }

        public BookVO Parse(Book origin)
        {
            if (origin == null)
                return new BookVO();

            return new BookVO
            {
                Id = origin.Id,
                Title = origin.Title,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price
            };
        }

        public List<BookVO> ParseList(List<Book> origin)
        {
            if (origin == null)
                return new List<BookVO>();

            return origin.Select(item => Parse(item)).ToList();
        }
    }
}