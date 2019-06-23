using dyp.contracts;
using dyp.contracts.dto;
using dyp.dyp.tests.mock;
using dyp.dyp.tests.test_datas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace dyp.dyp.tests
{
    [TestClass]
    public class TournamentManagementRequestHandlerTests
    {
        //private ITournamentRepository _tournament_repo;
        //private IPersonRepository _person_repo;
        //private TournamentDirector _director;
        //private TournamentManagementRequestHandler _sut;

        //[TestInitialize]
        //public void Initialize()
        //{
        //    _director = new TournamentDirector();
        //    _tournament_repo = new TournamentRepositoryMock();
        //    _person_repo = new PersonRepositoryMock();
        //    _sut = new TournamentManagementRequestHandler(_director, _tournament_repo, _person_repo);
        //}

        //[TestMethod]
        //public void Turnier_with_two_sets()
        //{
        //    var request = new CreateTournamentRequestDto();
        //    request.Name = "Test Turnier";
        //    request.Competitors = CompetitorTestDatas.Competitors().Select(c => c.Person.Id.ToString()).ToArray();
        //    request.Points = 2;
        //    request.PointsTied = 0;
        //    request.Sets = 2;
        //    request.Tables = 1;
        //    request.Walkover = true;
        //    request.Tied = false;
        //    request.FairLots = false;

        //    var result = _sut.Create_tournament(request);

        //    Assert.AreEqual(2, result.Round.Matches.Count());
        //    Assert.AreEqual(2, result.Round.Matches.ElementAt(0).SetsToWin);
        //    Assert.AreEqual(3, result.Round.Matches.ElementAt(0).MaxSetsToPlay);
        //}

        //[TestCleanup]
        //public void CleanUp()
        //{
        //    _sut = null;
        //    _tournament_repo = null;
        //    _person_repo = null;
        //    _director = null;
        //}
    }
}
