using System;
using System.Linq;
using Domain.Generic;

namespace Domain.DependencyContracts
{
    public interface IUnitOfWork : IDisposable
    {
        void AddNew(DomainObject obj);

        void Remove(DomainObject obj);

        void Attach(DomainObject obj);

        IQueryable<TDomainObject> GetSelection<TDomainObject>()
            where TDomainObject : DomainObject;

        void Commit();
    }
}
