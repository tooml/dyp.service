using dyp.data;
using dyp.dyp.tests.test_datas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace dyp.dyp.tests
{
    [TestClass]
    public class TournamentDirectorTests
    {
        private TournamentDirector _sut;
        private Options _options;
        private IEnumerable<Competitor> _competitors;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new TournamentDirector();

            _options = new Options()
            {
                Tables = 1,
                Sets = 2,
                Points = 2,
                Tied = false,
                Points_on_tied = 0,
                Walkover = true,
                Fair_lots = false
            };

            _competitors = CompetitorTestDatas.Competitors();
        }

        [TestMethod]
        public void First_round_with_2_matches()
        {
            var result = _sut.New_round(_competitors.Take(8), _options, 0);

            Assert.AreEqual(2, result.Matches.Count());
            Assert.AreEqual("Runde 1", result.Name);
            Assert.IsNotNull(result.Id);
        }

        [TestMethod]
        public void Fifth_round_with_1_match()
        {
            var result = _sut.New_round(_competitors.Take(7), _options, 4);

            Assert.AreEqual(1, result.Matches.Count());
            Assert.AreEqual("Runde 5", result.Name);
            Assert.IsNotNull(result.Id);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _sut = null;
            _options = null;
            _competitors = null;
        }
    }
}
