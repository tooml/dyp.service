using System;

namespace dyp.data
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PersonStatistics Statistics { get; set; } = new PersonStatistics();

        public string Get_person_full_name()
        {
            return string.Concat(FirstName, " ", LastName);
        }
    }
}
