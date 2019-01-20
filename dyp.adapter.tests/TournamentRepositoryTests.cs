using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using dyp.data;
using System.Linq;
using dyp.contracts;

namespace dyp.adapter.tests
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für TurnierRepositoryTests
    /// </summary>
    [TestClass]
    public class TournamentRepositoryTests
    {
        private const string REPO_PATH = "turnier";

        private string _dbPath;
        private ITournamentRepository _sut;

        [TestInitialize]
        public void Initialize()
        {
            if (Directory.Exists(REPO_PATH)) Directory.Delete(REPO_PATH, true);
            Directory.CreateDirectory(REPO_PATH);

            _dbPath = Directory.GetCurrentDirectory();
            _sut = new TournamentRepository(_dbPath);
        }

        [TestMethod]
        public void Save_tournament()
        {
            var tournament = new Tournament();
            tournament.Id = IdGeneratorMock.Deliver_id().ElementAt(0);
            tournament.Name = "Test Turnier";

            _sut.Save(tournament);

            Assert.AreEqual(true, true);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _sut = null;
        }
    }
}
