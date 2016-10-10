using System;
using Domain.DependencyContracts;
using Effort;
using Events;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence;
using Persistence.Migrations;
using Persistence.UoW;

namespace Tests.Base
{
    public class TestFactory
    {
        protected IUnitOfWork _UnitOfWork;
        protected UnitOfWorkDbContext _AssertUoW;

        [TestInitialize]
        public void InitTest()
        {
            var connection = DbConnectionFactory.CreatePersistent("test");
            _UnitOfWork = new UnitOfWork(connection);
            new Configuration().SeedDB((UnitOfWork) _UnitOfWork);
            _UnitOfWork.Commit();
            EventAPI.RegisterAll(_UnitOfWork);

            _AssertUoW = new UnitOfWorkDbContext(connection);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _UnitOfWork.Dispose();
            _AssertUoW.Dispose();
            _UnitOfWork.Dispose();

        }
    }
}
