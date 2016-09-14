using System;
using Domain.ApplicationModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.DependencyContracts;
using Persistence;
using Persistence.UoW;

namespace Persistence.Test.UoW
{
    [TestClass]
    public class UnitOfWorkTest
    {

        private IUnitOfWork _UnitOfWork;
        private string _connectionString;

        [TestInitialize]
        public void InitTest()
        {
            _connectionString = $"Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Temp_{Guid.NewGuid().ToString()}.mdf;Integrated Security=True";
            _UnitOfWork = new UnitOfWork(_connectionString);
        }


        [TestMethod]
        public void AddNewTest()
        {
            var gebr = new Gebruiker("tester");

            _UnitOfWork.AddNew(gebr);
            _UnitOfWork.Commit();


        }

        [TestMethod]
        public void QueryTest()
        {
            var gebr = new Gebruiker("tester");

            _UnitOfWork.AddNew(gebr);
            _UnitOfWork.Commit();
        }



        [TestCleanup]
        public void Cleanup()
        {
            _UnitOfWork.Dispose();

            var con = new UnitOfWorkDbContext();

            con.Database.Connection.Close();
            con.Database.Connection.ConnectionString = _connectionString;
            con.Database.Delete();

        }
    }
}
