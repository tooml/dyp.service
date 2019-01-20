using dyp.contracts;
using dyp.data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace dyp.adapter.tests
{
    [TestClass]
    public class PersonRepositoryTests
    {
        private const string REPO_PATH = "persons";

        private string _dbPath;
        private IPersonRepository _sut;

        [TestInitialize]
        public void Initialize()
        {
            if (Directory.Exists(REPO_PATH)) Directory.Delete(REPO_PATH, true);
            Directory.CreateDirectory(REPO_PATH);

            _dbPath = Directory.GetCurrentDirectory();
            _sut = new PersonRepository(_dbPath);
        }

        [TestMethod]
        public void Save_and_load_persons()
        {
            var person_one = new Person() { Id = IdGeneratorMock.Deliver_id().ElementAt(0), First_name = "Person", Last_name = "One" };
            var person_two = new Person() { Id = IdGeneratorMock.Deliver_id().ElementAt(1), First_name = "Person", Last_name = "Two" };
            var person_three = new Person() { Id = IdGeneratorMock.Deliver_id().ElementAt(2), First_name = "Person", Last_name = "Three" };

            _sut.Save(new Person[] { person_one, person_two, person_three });
            var persons = _sut.Load().ToList();

            Assert.AreEqual(3, persons.Count());
        }

        [TestCleanup]
        public void Cleanup()
        {
            _sut = null;
        }
    }
}
