using System;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using Domain.DependencyContracts;
using Domain.Generic;
using Domain.Helper;
using Persistence.UoW;

namespace Persistence
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DbContext _ConnectionDB;

        public UnitOfWork(string connectionString)
        {
            _ConnectionDB = new UnitOfWorkDbContext();
            
            _ConnectionDB.Database.Connection.Close();
            _ConnectionDB.Database.Connection.ConnectionString = connectionString;
            _ConnectionDB.Database.CreateIfNotExists();
            _ConnectionDB.Database.Connection.Open();
        }

        public UnitOfWork(DbConnection connection)
        {
            _ConnectionDB = new UnitOfWorkDbContext(connection);
        }

        public UnitOfWork()
        {
            _ConnectionDB = new UnitOfWorkDbContext();
        }

        public void AddNew(DomainObject obj)
        {
            _ConnectionDB.Entry(obj).State = EntityState.Added;
        }

        public void Remove(DomainObject obj)
        {
            _ConnectionDB.Entry(obj).State = EntityState.Deleted;
        }

        public void Attach(DomainObject obj)
        {
            _ConnectionDB.Entry(obj).State = EntityState.Modified;
        }

        public IQueryable<TDomainObject> GetSelection<TDomainObject>()
            where TDomainObject : DomainObject
        {
            return _ConnectionDB.Set<TDomainObject>().AsQueryable();
        }

        public void Commit()
        {
            string melding = "";
            var valList = _ConnectionDB.GetValidationErrors();
            if (valList.Any())
            {
                foreach (var valentry in valList)
                {
                    foreach (var val in valentry.ValidationErrors)
                    {
                        melding = $"{melding}/{val.ErrorMessage}";
                    }
                }
                FoutMelding.Maak(melding);
            }

            _ConnectionDB.Database.BeginTransaction();

            try
            {
                _ConnectionDB.SaveChanges();
                _ConnectionDB.Database.CurrentTransaction.Commit();
            }
            catch (Exception ex)
            {
                _ConnectionDB.Database.CurrentTransaction.Rollback();
                FoutMelding.Maak($"ERROR: {ex.InnerException.InnerException.Message}");
            }
        }

        public void Dispose()
        {
            _ConnectionDB.Database.Connection.Close();
        }
    }
}
