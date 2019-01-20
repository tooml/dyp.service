using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dyp.data;
using dyp.dyp.tests.test_datas;
using System.Linq;

namespace dyp.dyp.tests
{
    [TestClass]
    public class FixtureGeneratorTests
    {
        private FixtureGenerator _sut;
        private Options _options;
        private IEnumerable<Competitor> _competitors;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new FixtureGenerator();
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
        public void FixtureGenerator_acceptance()
        {
            _options.Tied = true;

            var result = _sut.Start_fixture_generation(_competitors, _options).ToList();

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(2, result.ElementAt(0).Sets_to_win);
            Assert.AreEqual(2, result.ElementAt(0).Max_sets_to_play);
        }

        [TestMethod]
        public void FixtureGenerator_acceptance_walkover()
        {
            var test_competitors = _competitors.Take(6);
            var c_one = test_competitors.ElementAt(0).Walkover_count = 1;
            var c_two = test_competitors.ElementAt(1).Walkover_count = 3;
            var c_three = test_competitors.ElementAt(2).Walkover_count = 2;
            var c_four = test_competitors.ElementAt(3).Walkover_count = 4;
            var c_five = test_competitors.ElementAt(4).Walkover_count = 3;
            var c_six = test_competitors.ElementAt(5).Walkover_count = 1;

            _options.Tied = false;
            _options.Sets = 5;

            var result = _sut.Start_fixture_generation(test_competitors, _options).ToList();

            var fixture_competitors_ids = new List<Guid>();
            fixture_competitors_ids.Add(result.ElementAt(0).Home.Member_one.Id);
            fixture_competitors_ids.Add(result.ElementAt(0).Home.Member_two.Id);
            fixture_competitors_ids.Add(result.ElementAt(0).Away.Member_one.Id);
            fixture_competitors_ids.Add(result.ElementAt(0).Away.Member_two.Id);

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(9, result.ElementAt(0).Max_sets_to_play);

            //Walkover wird beim Aussetzen erhöht
            Assert.AreEqual(2, test_competitors.ElementAt(0).Walkover_count);

            //Erster und sechster Competitor muss aussetzten
            CollectionAssert.DoesNotContain(fixture_competitors_ids, test_competitors.ElementAt(0).Id);
            CollectionAssert.DoesNotContain(fixture_competitors_ids, test_competitors.ElementAt(5).Id);

            //Vierter Competitor muss vorhanden sein
            CollectionAssert.Contains(fixture_competitors_ids, test_competitors.ElementAt(3).Id);

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
