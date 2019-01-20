using dyp.adapter;
using dyp.contracts;
using dyp.contracts.dto;
using dyp.data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dyp.dyp
{
    public class TournamentManagementRequestHandler : ITournamentManagementRequestHandler
    {
        private readonly ITournamentRepository _tournament_repo;
        private readonly IPersonRepository _person_repo;
        private readonly TournamentDirector _director;

        public TournamentManagementRequestHandler(TournamentDirector director, ITournamentRepository tournament_repo, IPersonRepository person_repo)
        {
            _tournament_repo = tournament_repo;
            _person_repo = person_repo;
            _director = director;
        }

        public TournamentCreatedResponseDto Create_tournament(CreateTournamentRequestDto create_request)
        {
            var tournament = Initialize_tournament_datas(create_request);
            var competitors_ids = create_request.Competitors.Select(id => new Guid(id));
            var competitors = Initialize_tournament_competitors(create_request);
            tournament.Competitors = competitors.ToList();

            var first_round = _director.New_round(tournament.Competitors, tournament.Options, 0);
            tournament.Rounds.Add(first_round);
            _tournament_repo.Save(tournament);

            return Map(tournament);
        }

        private Tournament Initialize_tournament_datas(CreateTournamentRequestDto create_request)
        {
            var tournament = new Tournament();
            tournament.Id = IdGenerator.Deliver_id();
            tournament.Name = create_request.Name;
            tournament.Date = DateProvider.Get_current_date();

            var options = new Options();
            options.Tables = create_request.Tables;
            options.Points = create_request.Points;
            options.Sets = create_request.Sets;
            options.Points_on_tied = create_request.PointsTied;
            options.Tied = create_request.Tied;
            options.Walkover = create_request.Walkover;
            options.Fair_lots = create_request.FairLots;

            tournament.Options = options;
            tournament.Rounds = new List<Round>();

            return tournament;
        }

        private IEnumerable<Competitor> Initialize_tournament_competitors(CreateTournamentRequestDto create_request)
        {
            var competitors_ids = create_request.Competitors.Select(id => new Guid(id));
            return _person_repo.Load(competitors_ids).Select(person => new Competitor()
            {
                Id = IdGenerator.Deliver_id(),
                Person = person,
                Walkover_count = 0
            });
        }

        private TournamentCreatedResponseDto Map(Tournament tournament)
        {
            return new TournamentCreatedResponseDto()
            {
                Id = tournament.Id.ToString(),
                Name = tournament.Name,
                Round = new RoundResponseDto()
                {
                    Name = tournament.Rounds.First().Name,
                    Matches = tournament.Rounds.First().Matches
                                .Select(fixture => new FixtureResponseDto()
                                {
                                    Id = fixture.Id.ToString(),
                                    Home = fixture.Home.Get_team_name(),
                                    Away = fixture.Away.Get_team_name(),
                                    Tied = tournament.Options.Tied,
                                    SetsToWin = fixture.Sets_to_win,
                                    MaxSetsToPlay = fixture.Max_sets_to_play
                                }).ToArray()
                }
            };
        }
    }
}
