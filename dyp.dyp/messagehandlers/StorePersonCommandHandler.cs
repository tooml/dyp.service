using dyp.contracts;
using dyp.contracts.messages;
using dyp.contracts.messages.commands.storeperson;
using dyp.data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dyp.dyp.messagehandlers
{
    //public class StorePersonCommandHandler : IStorePersonCommandHandling
    //{
    //    private readonly IPersonRepository _person_repo;

    //    public StorePersonCommandHandler(IPersonRepository person_repo)
    //    {
    //        _person_repo = person_repo;
    //    }

    //    public CommandStatus Handle(StorePersonCommand request)
    //    {
    //        var stored = _person_repo.Load().ToList();

    //        var persons = Update_or_crate_Person(stored, request);
    //        _person_repo.Save(persons);

    //        return new Success();
    //    }

    //    private IEnumerable<Person> Update_or_crate_Person(List<Person> persons, StorePersonCommand request)
    //    {
    //        if (persons.Exists(person => person.Id.Equals(request.Id)))
    //        {
    //            var index = persons.FindIndex(pers => pers.Id.Equals(request.Id));
    //            persons.ElementAt(index).FirstName = request.FirstName;
    //            persons.ElementAt(index).LastName = request.LastName;
    //        }
    //        else
    //        {
    //            var person = new Person()
    //            {
    //                Id = request.Id,
    //                FirstName = request.FirstName,
    //                LastName = request.LastName,
    //            };

    //            persons.Add(person);
    //        }

    //        return persons;
    //    }
    //}
}
