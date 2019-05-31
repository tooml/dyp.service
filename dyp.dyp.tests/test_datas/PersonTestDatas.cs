using dyp.data;
using System;
using System.Collections.Generic;

namespace dyp.dyp.tests.test_datas
{
    public static class PersonTestDatas
    {
        public static IEnumerable<Person> Persons()
        {
            return new Person[] { new Person()
            {
                Id = new Guid("4285a9df-6f92-4f08-be13-5eb68e1d1e77"),
                FirstName = "Person First 1",
                LastName = "Person Last 1",
                Statistics = new PersonStatistics()
            },
            new Person()
            {
                Id = new Guid("3357e532-0410-43ea-add2-c21434dca0de"),
                FirstName = "Person First 2",
                LastName = "Person Last 2",
                Statistics = new PersonStatistics()
            },
            new Person()
            {
                Id = new Guid("63ad6b01-384f-445d-b0cc-3ba1e22e50df"),
                FirstName = "Person First 3",
                LastName = "Person Last 3",
                Statistics = new PersonStatistics()
            },
            new Person()
            {
                Id = new Guid("9514b766-fbdf-4732-a20e-7e9afe2c500e"),
                FirstName = "Person First 4",
                LastName = "Person Last 4",
                Statistics = new PersonStatistics()
            },
            new Person()
            {
                Id = new Guid("8c1e10ba-676c-4c99-831d-8b8c3e5a14b0"),
                FirstName = "Person First 5",
                LastName = "Person Last 5",
                Statistics = new PersonStatistics()
            },
            new Person()
            {
                Id = new Guid("5c424d03-6382-494f-ba4d-a980c567612f"),
                FirstName = "Person First 6",
                LastName = "Person Last 6",
                Statistics = new PersonStatistics()
            },
            new Person()
            {
                Id = new Guid("b1d59a7c-c851-40a0-bb86-d23294e4a08a"),
                FirstName = "Person First 7",
                LastName = "Person Last 7",
                Statistics = new PersonStatistics()
            },
            new Person()
            {
                Id = new Guid("a4040bfa-a91b-42b7-b23a-135e8ababc2c"),
                FirstName = "Person First 7",
                LastName = "Person Last 7",
                Statistics = new PersonStatistics()
            },
            new Person()
            {
                Id = new Guid("fbd43617-2374-4e62-9f7f-40963795943c"),
                FirstName = "Person First 7",
                LastName = "Person Last 7",
                Statistics = new PersonStatistics()
            },
            new Person()
            {
                Id = new Guid("986e297a-bb37-41ab-8676-3047b1a1b292"),
                FirstName = "Person First 7",
                LastName = "Person Last 7",
                Statistics = new PersonStatistics()
            },
            new Person()
            {
                Id = new Guid("44bd22c2-94d1-4e84-a5bc-cef7b45738a7"),
                FirstName = "Person First 7",
                LastName = "Person Last 7",
                Statistics = new PersonStatistics()
            }};
        }
    }
}
