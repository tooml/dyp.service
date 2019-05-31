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
        private readonly IPersonRepository _person_repo;

        public PersonsRequestHandler(IPersonRepository person_repo)
        {
            _person_repo = person_repo;
        }

        public PersonResponseDto[] Load_persons()
        {
            return _person_repo.Load().ToList().Select(person => Convert_to_PersonResponse(person)).ToArray();
        }

        public PersonResponseDto Create_person(CreatePersonRequestDto create_request)
        {
            var person = new Person()
            {
                Id = Guid.Parse(create_request.Id),
                FirstName = create_request.FirstName,
                LastName = create_request.LastName,
                Statistics = new PersonStatistics()
                {
                    Turnier_participations = 0,
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

        public PersonResponseDto Update_person(UpdatePersonRequestDto update_request)
        {
            var persons = _person_repo.Load().ToList();
            var update_person = persons.First(p => p.Id.Equals(update_request.Id));

            update_person.FirstName = update_request.FirstName;
            update_person.LastName = update_request.LastName;

            _person_repo.Save(persons);
            return Convert_to_PersonResponse(update_person);
        }

        private PersonResponseDto Convert_to_PersonResponse(Person person)
        {
            return new PersonResponseDto()
            {
                Id = person.Id.ToString(),
                FirstName = person.FirstName,
                LastName = person.LastName,
                TurnierParticipations = person.Statistics.Turnier_participations,
                Games = person.Statistics.Games,
                Wins = person.Statistics.Wins,
                Looses = person.Statistics.Looses
            };
        }
    }
}
