using dyp.contracts;
using dyp.contracts.messages.queries.tournament;
using dyp.data;
using System;
using System.Linq;
using static dyp.contracts.messages.queries.tournament.TournamentQueryResult.Enums;

namespace dyp.dyp.messagehandlers
{
    public class TournamentQueryHandler : ITournamentQueryHandling
    {
        private readonly ITournamentRepository _tournament_repo;

        public TournamentQueryHandler(ITournamentRepository tournament_repo)
        {
            _tournament_repo = tournament_repo;
        }

        public TournamentQueryResult Handle(TournamentQuery request)
        {
            var tournament = _tournament_repo.Load(new Guid[] { Guid.Parse(request.Id) }).Single();
            return Map(tournament);
        }

        private TournamentQueryResult Map(Tournament tournament)
        {
            return new TournamentQueryResult()
            {
                Id = tournament.Id.ToString(),
                Name = tournament.Name,
                Rounds = tournament.Rounds.Select(x =>
                {
                    return new TournamentQueryResult.Round()
                    {
                        Name = x.Name,
                        Matches = x.Matches
                                .Select(fixture => new TournamentQueryResult.Fixture()
                                {
                                    Id = fixture.Id.ToString(),
                                    Home = fixture.Home.Get_team_name(),
                                    Away = fixture.Away.Get_team_name(),
                                    Tied = tournament.Options.Tied,
                                    SetsToWin = fixture.Sets_to_win,
                                    MaxSetsToPlay = fixture.Max_sets_to_play,
                                    Sets = Enumerable.Range(0, fixture.Sets_to_win).Select(i =>
                                        new TournamentQueryResult.Set() { result = ResultStatus.None })
                                }).ToArray()
                    };
                })
            };
        }
    }
}
