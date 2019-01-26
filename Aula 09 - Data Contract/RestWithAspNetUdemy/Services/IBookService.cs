using RestWithAspNetUdemy.Data.VO;
using System.Collections.Generic;

namespace RestWithAspNetUdemy.Services
{
    public interface IBookService
    {
        BookVO Create(BookVO bookVO);
        BookVO FindById(long id);
        List<BookVO> FindAll();
        BookVO Update(BookVO bookVO);
        void Delete(long id);
    }
}
