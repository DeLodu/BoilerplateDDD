using System;
using Domain.ApplicationModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Domain.Test.BC_Accounts
{
    [TestClass]
    public class GebruikerTest
    {

        [TestMethod]
        public void GebruikerLeegAanmakenTest()
        {
            Action act = () => new Gebruiker("");

            act.ShouldThrow<Exception>().Where(e => e.Message == "Login moet minstens 3 karakters bevatten!");

        }

        [TestMethod]
        public void GebruikerTekortAanmakenTest()
        {
            Action act = () => new Gebruiker("AB");

            act.ShouldThrow<Exception>().Where(e => e.Message == "Login moet minstens 3 karakters bevatten!");

        }

        [TestMethod]
        public void GebruikerTelangAanmakenTest()
        {
            Action act = () => new Gebruiker("Azertyuiopqsdfghjklmwxcvbn Azertyuiopqsdfghjklmwxcvbn Azertyuiopqsdfghjklmwxcvbn Azertyuiopqsdfghjklmwxcvbn Azertyuiopqsdfghjklmwxcvbn Azertyuiopqsdfghjklmwxcvbn Azertyuiopqsdfghjklmwxcvbn");

            act.ShouldThrow<Exception>().Where(e => e.Message == "Login mag maximum 50 karakters bevatten!");

        }

        [TestMethod]
        public void GebruikerNaamTest()
        {
            var gebr = new Gebruiker("Tester");

            gebr.SetNaam("Test Azerty");

            gebr.Naam.Should().Be("Test Azerty");

        }

        [TestMethod]
        public void GebruikerNaamTelangTest()
        {
            var gebr = new Gebruiker("Tester");

            Action act = () => gebr.SetNaam("Azertyuiopqsdfghjklmwxcvbn Azertyuiopqsdfghjklmwxcvbn Azertyuiopqsdfghjklmwxcvbn Azertyuiopqsdfghjklmwxcvbn Azertyuiopqsdfghjklmwxcvbn Azertyuiopqsdfghjklmwxcvbn Azertyuiopqsdfghjklmwxcvbn");

            act.ShouldThrow<Exception>().Where(e => e.Message == "Naam mag maximum 100 karakters bevatten!");

        }
        
        [TestMethod]
        public void GebruikerPaswoordInstellenTest()
        {
            var gebr = new Gebruiker("Tester");

            gebr.SetPassword("TestPaswoord1");

            gebr.Salt.Should().NotBeNullOrEmpty();
            gebr.PasswordHash.Should().NotBeNullOrEmpty();

        }

        [TestMethod]
        public void GebruikerPaswoordTekortTest()
        {
            var gebr = new Gebruiker("Tester");

            Action act = () => gebr.SetPassword("Test1");

            act.ShouldThrow<Exception>().Where(e => e.Message == "Paswoord moet minimum 8 karakters lang zijn!");

        }

        [TestMethod]
        public void GebruikerPaswoordGeenCijferTest()
        {
            var gebr = new Gebruiker("Tester");

            Action act = () => gebr.SetPassword("TestPaswoord");

            act.ShouldThrow<Exception>().Where(e => e.Message == "Paswoord moet kleine, grote letters en cijfers bevatten!");

        }

        [TestMethod]
        public void GebruikerPaswoordGeenHoofdletterTest()
        {
            var gebr = new Gebruiker("Tester");

            Action act = () => gebr.SetPassword("testpaswoord1");

            act.ShouldThrow<Exception>().Where(e => e.Message == "Paswoord moet kleine, grote letters en cijfers bevatten!");

        }

        [TestMethod]
        public void GebruikerPaswoordControlerenTest()
        {
            var gebr = new Gebruiker("Tester");

            gebr.SetPassword("TestPaswoord1");

            gebr.VerifyPassword("TestPaswoord1").Should().BeTrue();
        }

    }
}
