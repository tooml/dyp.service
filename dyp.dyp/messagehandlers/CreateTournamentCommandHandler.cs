using dyp.contracts;
using dyp.contracts.messages;
using dyp.contracts.messages.commands.createtournament;
using dyp.data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dyp.dyp.messagehandlers
{
    //public class CreateTournamentCommandHandler : ICreateTournamentCommandHandling
    //{
    //    private readonly ITournamentRepository _tournament_repo;
    //    private readonly IPersonRepository _person_repo;
    //    private readonly IIdProvider _id_provider;
    //    private readonly IDateProvider _date_Provider;
    //    private readonly TournamentDirector _director;


    //    public CreateTournamentCommandHandler(ITournamentRepository tournament_repo, 
    //                                          IPersonRepository person_repo,
    //                                          IIdProvider id_provider, IDateProvider date_Provider,
    //                                          TournamentDirector director)
    //    {
    //        _tournament_repo = tournament_repo;
    //        _person_repo = person_repo;
    //        _id_provider = id_provider;
    //        _date_Provider = date_Provider;
    //        _director = director;
    //    }

    //    public CommandStatus Handle(CreateTournamentCommand command)
    //    {
    //        var tournament = Initialize_tournament_datas(command);
    //        var competitors = Initialize_tournament_competitors(command.competitorsIds);
    //        tournament.Competitors = competitors.ToList();

    //        var first_round = _director.New_round(tournament.Competitors, tournament.Options, 0);
    //        tournament.Rounds.Add(first_round);
    //        _tournament_repo.Save(tournament);

    //        return new Success();
    //    }

    //    private Tournament Initialize_tournament_datas(CreateTournamentCommand command)
    //    {
    //        var tournament = new Tournament();
    //        tournament.Id = _id_provider.Get_new_id();
    //        tournament.Name = command.Name;
    //        tournament.Date = _date_Provider.Get_current_date();

    //        var options = new Options();
    //        options.Tables = command.Tables;
    //        options.Points = command.Points;
    //        options.Sets = command.Sets;
    //        options.Points_on_tied = command.PointsTied;
    //        options.Tied = command.Tied;
    //        options.Walkover = command.Walkover;
    //        options.Fair_lots = command.FairLots;

    //        tournament.Options = options;
    //        tournament.Rounds = new List<Round>();

    //        return tournament;
    //    }

    //    private IEnumerable<Competitor> Initialize_tournament_competitors(IEnumerable<string> competitors_ids)
    //    {
    //        var ids = competitors_ids.Select(id => Guid.Parse(id));

    //        return _person_repo.Load(ids).Select(person => new Competitor()
    //        {
    //            Id = _id_provider.Get_new_id(),
    //            Person = person,
    //            Walkover_count = 0
    //        });
    //    }
    //}
}
