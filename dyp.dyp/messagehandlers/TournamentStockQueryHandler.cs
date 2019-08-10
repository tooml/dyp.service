using dyp.contracts;
using dyp.contracts.messages.queries.tournamentstock;
using dyp.data;
using System.Collections.Generic;
using System.Linq;
using static dyp.contracts.messages.queries.tournamentstock.TournamentStockQueryResult;

namespace dyp.dyp.messagehandlers
{
    //public class TournamentStockQueryHandler : ITournamentStockQueryHandling
    //{
    //    private readonly ITournamentRepository _tournament_repo;

    //    public TournamentStockQueryHandler(ITournamentRepository tournament_repo)
    //    {
    //        _tournament_repo = tournament_repo;
    //    }

    //    public TournamentStockQueryResult Handle(TournamentStockQuery request)
    //    {
    //        var tournaments = _tournament_repo.Load();
    //        var tournaments_infos = Map(tournaments).ToList();
    //        return new TournamentStockQueryResult() { TournamentInfos = tournaments_infos };
    //    }

    //    private IEnumerable<TournamentInfo> Map(IEnumerable<Tournament> tournaments)
    //    {
    //        return tournaments.Select(tournament => new TournamentInfo()
    //        {
    //            Id = tournament.Id.ToString(),
    //            Name = tournament.Name,
    //            Created = tournament.Date
    //        });
    //    }
    //}
}
