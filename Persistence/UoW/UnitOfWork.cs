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
        internal DbContext ConnectionDB { get; set; }

        public UnitOfWork(DbConnection connection)
        {
            ConnectionDB = new UnitOfWorkDbContext(connection);
        }

        public UnitOfWork()
        {
            ConnectionDB = new UnitOfWorkDbContext();
        }

        public void AddNew(DomainObject obj)
        {
            ConnectionDB.Entry(obj).State = EntityState.Added;
        }

        public void Remove(DomainObject obj)
        {
            ConnectionDB.Entry(obj).State = EntityState.Deleted;
        }

        public void Attach(DomainObject obj)
        {
            ConnectionDB.Entry(obj).State = EntityState.Modified;
        }

        public IQueryable<TDomainObject> GetSelection<TDomainObject>()
            where TDomainObject : DomainObject
        {
            return ConnectionDB.Set<TDomainObject>().AsQueryable();
        }

        public void Commit()
        {
            string melding = "";
            var valList = ConnectionDB.GetValidationErrors();
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

            ConnectionDB.Database.BeginTransaction();

            try
            {
                ConnectionDB.SaveChanges();
                ConnectionDB.Database.CurrentTransaction.Commit();
            }
            catch (Exception ex)
            {
                ConnectionDB.Database.CurrentTransaction.Rollback();
                FoutMelding.Maak($"ERROR: {ex.InnerException.InnerException.Message}");
            }
        }

        public void Dispose()
        {
            ConnectionDB.Database.Connection.Close();
        }
    }
}
