using System;
using System.Data.Entity;
using System.Linq;
using Domain.KanbanModule.Taak;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Base;

namespace Tests.Domain.KanbanModule
{
    [TestClass]
    public class TaakTest : TestFactory
    {

        [TestMethod]
        public void TaakAanmakenTest()
        {
            var result = new Taak("test");
            result.SetOmschrijvingLang("test lang");

            result.Status.Naam.Should().Be("Nieuw");
            result.OmschrijvingKort.Should().Be("test");
            result.OmschrijvingLang.Should().Be("test lang");
        }

        [TestMethod]
        public void TaakStatusNullTest()
        {
            var result = new Taak("test");

            Action act = () => result.SetStatus(null);

            act.ShouldThrow<Exception>().Where(e => e.Message == "Status kan niet NULL zijn!");
        }

        [TestMethod]
        public void TaakVeranderStatusTest()
        {
            var result = new Taak("test");
            var status = _UnitOfWork.GetSelection<Status>().OrderBy(e => e.UID).Skip(1).FirstOrDefault();

            result.SetStatus(status);

            result.Status.Naam.Should().Be(status.Naam);
        }

        [TestMethod]
        public void TaakAanmakenNULLTest()
        {
            Action act1 = () => new Taak("");
            Action act2 = () => new Taak(null);

            act1.ShouldThrow<Exception>().Where(e => e.Message == "Omschrijving is verplicht!");
            act2.ShouldThrow<Exception>().Where(e => e.Message == "Omschrijving is verplicht!");
        }
    }
}
