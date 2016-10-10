using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Domain.KanbanModule.Taak;
using Tests.Base;

namespace Tests.Persistence.UoW
{
    [TestClass]
    public class UnitOfWorkTest : TestFactory
    {

        [TestMethod]
        public void AddNewTest()
        {
            var ent = new Taak("test");
            
            _UnitOfWork.AddNew(ent);
            _UnitOfWork.Commit();

            var result = _AssertUoW.Taken.FirstOrDefault(e => e.UID == ent.UID);

            result.Should().NotBeNull();
        }

        [TestMethod]
        public void QueryTest()
        {
            var result = _UnitOfWork.GetSelection<Status>().Where(e => e.Naam != "Nieuw");

            result.Count().Should().Be(3);
        }


        // remove from collection


        




    }
}
