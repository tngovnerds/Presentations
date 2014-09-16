using System.Collections.Generic;
using System.Linq;
using Smackdown.Models;

namespace Smackdown.Repositories
{
    public class PersonRepository
    {
        private static readonly List<Person> People = new List<Person>();

        static PersonRepository()
        {
            People.Add(new Person
            {
                Id=0,
                FirstName = "Brian",
                LastName = "Cox",
                Addresses = new List<Address>
                {
                    new Address
                    {
                        Id=0,
                        City = "Nashville",
                        State = "TN",
                        ZipCode = "37211",
                        Street = "6124 Stillmeadow Drive"
                    },
                    new Address {Id = 1,City = "Nashville", State = "TN", ZipCode = "37076", Street = "649 Dutchmans Drive"}
                }
            });
        }

        public IList<Person> Get()
        {
            return People;
        }

        public Person Get(int id)
        {
            return People.FirstOrDefault(p => p.Id == id);
        }

        public void Save(Person person)
        {
            //add or update?  
            if (person.Id.HasValue)
            {
                var indx = People.FindIndex(p => p.Id == person.Id);
                if (indx >= 0)
                    People[indx] = person;
                else
                    People.Add(person);
            }
            else
            {
                person.Id = GetNextId();
                People.Add(person);
            }
        }

        public void SaveAddress(int personId, Address address)
        {
            var person = People.First(p => p.Id == personId);
            if (address.Id.HasValue)
            {
                var indx = person.Addresses.FindIndex(p => p.Id == address.Id);
                if (indx >= 0)
                    person.Addresses[indx] = address;
                else
                    person.Addresses.Add(address);
            }
            else
            {
                address.Id = GetNextId(person.Addresses);
                person.Addresses.Add(address);
            }
        }

        private int GetNextId()
        {
            return People.Count;
        }

        private int GetNextId(IList<Address> addresses)
        {
            return addresses.Count;
        }

    }
}
