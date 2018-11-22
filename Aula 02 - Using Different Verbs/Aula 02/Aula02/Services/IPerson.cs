using Aula02.Model;
using System.Collections.Generic;

namespace Aula02.Services
{
    public interface IPerson
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long Id);
    }
}
