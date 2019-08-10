using dyp.contracts;
using dyp.contracts.messages.queries.personstock;
using System.Linq;

namespace dyp.dyp.messagehandlers
{
    //public class PersonStockQueryHandler 
    //{
    //    private readonly IPersonRepository _person_repo;

    //    public PersonStockQueryHandler(IPersonRepository person_repo) { _person_repo = person_repo; }

    //    public PersonStockQueryResult Handle(PersonStockQuery request)
    //    {
    //        var persons = _person_repo.Load();
    //        return new PersonStockQueryResult
    //        {
    //            Persons = persons.Select(Map).ToArray()
    //        };
    //    }

    //    private PersonStockQueryResult.Person Map(data.Person person)
    //    {
    //        return new PersonStockQueryResult.Person()
    //        {
    //            Id = person.Id,
    //            FirstName = person.FirstName,
    //            LastName = person.LastName,
    //            TurnierParticipations = person.Statistics.Turnier_participations,
    //            Games = person.Statistics.Games,
    //            Wins = person.Statistics.Wins,
    //            Looses = person.Statistics.Looses
    //        };
    //    }
    //}
}
