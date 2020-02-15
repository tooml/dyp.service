using System;

namespace dyp.data
{
    public class Person
    {
        public Guid Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public PersonStatistics Statistics { get; set; } = new PersonStatistics();

        public string Get_person_full_name()
        {
            return string.Concat(First_name, " ", Last_name);
        }
    }
}
