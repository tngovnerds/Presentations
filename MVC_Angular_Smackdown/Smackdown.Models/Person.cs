using System.Collections.Generic;

namespace Smackdown.Models
{
    public class Person
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Address> Addresses { get; set; }

        public Person()
        {
            Addresses = new List<Address>();
        }
    }
}
