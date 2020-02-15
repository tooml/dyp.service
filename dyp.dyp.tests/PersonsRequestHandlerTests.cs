using System;
using System.IO;
using System.Linq;
using dyp.adapter;
using dyp.adapter.tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dyp.dyp.tests
{
    [TestClass]
    public class PersonsRequestHandlerTests
    {
        //private const string REPO_PATH = "persons";

        //private string _dbPath;
        //private PersonRepository _person_repo;
        //private PersonsRequestHandler _sut;

        //[TestInitialize]
        //public void Initialize()
        //{
        //    if (Directory.Exists(REPO_PATH)) Directory.Delete(REPO_PATH, true);

        //    _dbPath = Directory.GetCurrentDirectory();

        //    _person_repo = new PersonRepository(_dbPath);
        //    _sut = new PersonsRequestHandler(_person_repo);
        //}

        //[TestMethod]
        //public void PersonsRequestHandler_acceptance_test()
        //{
        //    //Create and Load
        //    var person_to_create_one = new CreatePersonRequestDto()
        //    {
        //        Id = IdGeneratorMock.Deliver_id().ElementAt(0).ToString(),
        //        FirstName = "Person",
        //        LastName = "One"
        //    };

        //    var person_to_create_two = new CreatePersonRequestDto()
        //    {
        //        Id = IdGeneratorMock.Deliver_id().ElementAt(1).ToString(),
        //        FirstName = "Person",
        //        LastName = "Two"
        //    };

        //    _sut.Create_person(person_to_create_one);
        //    _sut.Create_person(person_to_create_two);

        //    var persons_list = _sut.Load_persons().ToList();

        //    Assert.AreEqual(2, persons_list.Count());
        //    Assert.AreEqual("Person", persons_list.First().FirstName);
        //    Assert.AreEqual("One", persons_list.First().LastName);
        //    Assert.AreEqual(0, persons_list.First().Games);

        //    //Update
        //    var id = new Guid(persons_list.ElementAt(1).Id);
        //    var update_request = new UpdatePersonRequestDto() { Id = id, FirstName = "First", LastName = "Last" };
        //    _sut.Update_person(update_request);

        //    persons_list = _sut.Load_persons().ToList();
        //    Assert.AreEqual("Person", persons_list.First().FirstName);
        //    Assert.AreEqual("One", persons_list.First().LastName);
        //    Assert.AreEqual("First", persons_list.ElementAt(1).FirstName);
        //    Assert.AreEqual("Last", persons_list.ElementAt(1).LastName);
        //}

        //[TestCleanup]
        //public void Cleanup()
        //{
        //    _sut = null;
        //    _person_repo = null;
        //}
    }
}
