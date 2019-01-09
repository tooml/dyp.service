using dyp.adapter;
using dyp.contracts;
using dyp.contracts.dto;
using dyp.data;
using System;
using System.Linq;

namespace dyp.dyp
{
    public class PersonsRequestHandler : IPersonsRequestHandler
    {
        private readonly PersonRepository _person_repo;

        public PersonsRequestHandler(PersonRepository person_repo)
        {
            _person_repo = person_repo;
        }

        public PersonResponseDto[] Load_persons()
        {
            return _person_repo.Load().ToList().Select(person => Convert_to_PersonResponse(person)).ToArray();
        }

        public PersonResponseDto Create_person(CreatePersonRequestDto createRequest)
        {
            var person = new Person()
            {
                Id = Guid.Parse(createRequest.Id),
                First_name = createRequest.FirstName,
                Last_name = createRequest.LastName,
                Statistics = new PersonStatistics()
                {
                    TurnierParticipations = 0,
                    Games = 0,
                    Wins = 0,
                    Looses = 0
                }
            };

            var persons = _person_repo.Load().ToList();
            persons.Add(person);
            _person_repo.Save(persons);

            return Convert_to_PersonResponse(person);
        }

        public PersonResponseDto Update_person(UpdatePersonRequestDto updateRequest)
        {
            var persons = _person_repo.Load().ToList();
            var update_person = persons.First(p => p.Id.Equals(updateRequest.Id));

            update_person.First_name = updateRequest.FirstName;
            update_person.Last_name = updateRequest.LastName;

            _person_repo.Save(persons);
            return Convert_to_PersonResponse(update_person);
        }

        private PersonResponseDto Convert_to_PersonResponse(Person person)
        {
            return new PersonResponseDto()
            {
                Id = person.Id.ToString(),
                FirstName = person.First_name,
                LastName = person.Last_name,
                TurnierParticipations = person.Statistics.TurnierParticipations,
                Games = person.Statistics.Games,
                Wins = person.Statistics.Wins,
                Looses = person.Statistics.Looses
            };
        }
    }
}
