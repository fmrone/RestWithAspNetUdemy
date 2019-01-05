using System;
using System.Collections.Generic;
using System.Threading;
using Aula02.Model;

namespace Aula02.Services.Implementations
{
    public class PersonService : IPersonService
    {
        //volatile: é zerada quando a aplicação é (re)iniciada
        private volatile int count; 

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long Id)
        {
        }

        public List<Person> FindAll()
        {
            var persons = new List<Person>();

            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }

            return persons;
        }

        public Person FindById(long id)
        {
            return new Person {
                Id = IncrementAndGet(),
                FirstName = "Frederico",
                LastName = "Ribeiro",
                Address = "Contagem - MG",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = string.Format("First Name {0}", i),
                LastName = string.Format("Last Name {0}", i),
                Address = string.Format("Address {0}", i),
                Gender = string.Format("Gender {0}", i)
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
