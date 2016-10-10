using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.ApplicationModule.Logger;
using FluentAssertions;
using Tests.Base;

namespace Tests.Domain.ApplicationModule
{
    [TestClass]
    public class LogItemTest : TestFactory
    {
        [TestMethod]
        public void LogItemAanmakenTest()
        {
            var result = new LogItem("testmelding", "testlogin");

            result.Melding.Should().Be("testmelding");
            result.LoginNaam.Should().Be("testlogin");
        }

        [TestMethod]
        public void LogItemAanmakenLeegUserTest()
        {
            Action act = () => new LogItem("test","");

            act.ShouldThrow<Exception>().Where(ex => ex.Message == "LoginNaam is verplicht in te vullen!");
        }

        [TestMethod]
        public void LogItemAanmakenUserTelangTest()
        {
            Action act = () => new LogItem("test", "Azertyuiopqsdfghjklmwxcvbn Azertyuiopqsdfghjklmwxcvbn Azertyuiopqsdfghjklmwxcvbn Azertyuiopqsdfghjklmwxcvbn");

            act.ShouldThrow<Exception>().Where(ex => ex.Message == "LoginNaam mag maximum 50 karakters bevatten!");
        }

        [TestMethod]
        public void LogItemAanmakenLeegMeldingTest()
        {
            Action act = () => new LogItem("", "test");

            act.ShouldThrow<Exception>().Where(ex => ex.Message == "Melding is verplicht in te vullen!");
        }

        [TestMethod]
        public void LogItemAanmakenMeldingTelangTest()
        {
            Action act = () => new LogItem("Azertyuiopqsdfghjklmwxcvbn Azertyuiopqsdfghjklmwxcvbn Azertyuiopqsdfghjklmwxcvbn Azertyuiopqsdfghjklmwxcvbn Azertyuiopqsdfghjklmwxcvbn Azertyuiopqsdfghjklmwxcvbn", "test");

            act.ShouldThrow<Exception>().Where(ex => ex.Message == "Melding mag maximum 150 karakters bevatten!");
        }


    }
}
