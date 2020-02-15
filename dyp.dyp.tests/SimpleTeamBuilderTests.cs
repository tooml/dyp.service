using dyp.data;
using dyp.dyp.tests.test_datas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace dyp.dyp.tests
{
    [TestClass]
    public class SimpleTeamBuilderTests
    {
        //private SimpleTeamBuilder _sut;
        //private IEnumerable<Competitor> _competitors;

        //[TestInitialize]
        //public void Initialize()
        //{
        //    _sut = new SimpleTeamBuilder();
        //    _competitors = CompetitorTestDatas.Competitors();
        //}

        //[TestMethod]
        //public void Build_2_teams()
        //{
        //    var competitors_for_teams = _competitors.Take(4);

        //    var result = _sut.Determine_teams(competitors_for_teams).ToList();

        //    Assert.AreEqual(2, result.Count());

        //    Assert.IsNotNull(result.ElementAt(0).Member_one);
        //    Assert.IsNotNull(result.ElementAt(0).Member_two);
        //    Assert.IsNotNull(result.ElementAt(1).Member_one);
        //    Assert.IsNotNull(result.ElementAt(1).Member_two);

        //    Assert.IsNotNull(result.ElementAt(0).Get_team_name());
        //    Assert.IsNotNull(result.ElementAt(1).Member_two.Id);
        //    Assert.IsNotNull(result.ElementAt(0).Member_two.Person);
        //}

        //[TestCleanup]
        //public void Cleanup()
        //{
        //    _sut = null;
        //    _competitors = null;
        //}
    }
}
