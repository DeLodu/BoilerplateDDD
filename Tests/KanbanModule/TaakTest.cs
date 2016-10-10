using System;
using Domain.KanbanModule.Taak;
using Effort;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistence.UoW;

namespace Domain.Test.KanbanModule
{
    [TestClass]
    public class TaakTest
    {
        private UnitOfWorkDbContext _setupUoW;
        private string _connectionString;

        [TestInitialize]
        public void InitTest()
        {
            var connection = DbConnectionFactory.CreatePersistent("test");
            _setupUoW = new UnitOfWorkDbContext(connection);
        }


        [TestMethod]
        public void TaakAanmakenTest()
        {

            var result = new Taak("test");

            result.Status.Naam.Should().Be("");
            result.OmschrijvingKort.Should().Be("test");
            result.OmschrijvingLang.Should().Be("");
        }
    }
}
