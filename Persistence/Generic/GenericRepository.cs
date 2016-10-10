using System;
using System.Collections.Generic;
using Domain.DependencyContracts;
using Domain.Generic;

namespace Persistence.Generic
{
    public abstract class GenericRepository<TEntiteit> : IRepository<TEntiteit>
        where TEntiteit : Entiteit
    {
        private readonly IUnitOfWork _uow;

        protected internal readonly List<string> _includes = new List<string>();

        protected GenericRepository()
        {
            _uow = new UnitOfWork();
            GetIncludes();
        }

        protected GenericRepository(IUnitOfWork uow)
        {
            _uow = uow;
            GetIncludes();
        }

        protected virtual void GetIncludes()
        {
            
        }

        public TEntiteit GetByUid(Guid uID)
        {
            throw new NotImplementedException();
        }

        public TEntiteit GetGraphByUid(Guid uID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntiteit> GetSelection(Func<TEntiteit, bool> spec)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntiteit> GetPageSelection(Func<TEntiteit, bool> spec, int pagesize, int pagenummer, string sort, bool order)
        {
            throw new NotImplementedException();
        }

        public int GetSelectionTotal(Func<TEntiteit, bool> spec)
        {
            throw new NotImplementedException();
        }

        public void AddNew(TEntiteit ent)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntiteit ent)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntiteit ent)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
