using System;
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

        internal UnitOfWork(DbContext connectionDB)
        {
            _ConnectionDB = connectionDB;
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

        public IQueryable GetSelection<TDomainObject>()
            where TDomainObject : DomainObject
        {
            return _ConnectionDB.Set<TDomainObject>().AsQueryable();
        }

        public void Commit()
        {
            _ConnectionDB.Database.BeginTransaction();
            try
            {
                _ConnectionDB.SaveChanges();
            }
            catch (Exception ex)
            {
                _ConnectionDB.Database.CurrentTransaction.Rollback();
                FoutMelding.Maak(ex.Message);
            }
        }

        public void Dispose()
        {
            _ConnectionDB.Database.Connection.Close();
        }
    }
}
