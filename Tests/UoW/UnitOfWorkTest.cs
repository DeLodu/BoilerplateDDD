using System;
using System.Data.Entity;
using System.Linq;
using Effort;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Domain.DependencyContracts;
using Domain.KanbanModule.Taak;
using Persistence.UoW;

namespace Persistence.Test.UoW
{
    [TestClass]
    public class UnitOfWorkTest
    {
        private UnitOfWorkDbContext _setupUoW;
        private UnitOfWorkDbContext _assertUoW;
        private IUnitOfWork _UnitOfWork;
        private string _connectionString;

        [TestInitialize]
        public void InitTest()
        {
            var connection = DbConnectionFactory.CreatePersistent("test");
            _UnitOfWork = new UnitOfWork(connection);
            _setupUoW = new UnitOfWorkDbContext(connection);
            _assertUoW = new UnitOfWorkDbContext(connection);
        }

        [TestMethod]
        public void AddNewTest()
        {
            var ent = new Taak("test");
            
            _UnitOfWork.AddNew(ent);
            _UnitOfWork.Commit();

            var result = _assertUoW.Taken.FirstOrDefault(e => e.UID == ent.UID);

            result.Should().NotBeNull();
        }

        [TestMethod]
        public void QueryTest()
        {
            var ent1 = new Taak("Test1");
            var ent2 = new Taak("Test2");
            var ent3 = new Taak("Test3");

            _setupUoW.Entry(ent1).State = EntityState.Added;
            _setupUoW.Entry(ent2).State = EntityState.Added;
            _setupUoW.Entry(ent3).State = EntityState.Added;

            _setupUoW.SaveChanges();


            var result = _UnitOfWork.GetSelection<Taak>().FirstOrDefault(e => e.OmschrijvingKort == "Test1");

            result.OmschrijvingKort.Should().Be("Test1");
        }

        // remove from collection


        // attach

        

        [TestCleanup]
        public void Cleanup()
        {
            _UnitOfWork.Dispose();
            _assertUoW.Dispose();
            _setupUoW.Dispose();

        }
    }
}
