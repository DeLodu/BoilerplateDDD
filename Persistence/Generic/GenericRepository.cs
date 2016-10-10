using System;
using System.Collections.Generic;
using System.Linq;
using Domain.DependencyContracts;
using Domain.Generic;

namespace Persistence.Generic
{
    public abstract class GenericRepository<TEntiteit> : IRepository<TEntiteit>
        where TEntiteit : Entiteit
    {
        protected readonly IUnitOfWork _uow;

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

        protected internal virtual IQueryable<TDomainObject> GetSelect<TDomainObject>()
            where TDomainObject : DomainObject
        {
            return _uow.GetSelection<TDomainObject>().AsQueryable();
        }

        public TEntiteit GetByUid(Guid uID)
        {
            return GetSelect<TEntiteit>().FirstOrDefault(e => e.UID == uID);
        }

        public TEntiteit GetGraphByUid(Guid uID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntiteit> GetSelection(Func<TEntiteit, bool> spec)
        {
            return GetSelect<TEntiteit>().Where(spec).ToList();
        }

        public IEnumerable<TEntiteit> GetPageSelection(Func<TEntiteit, bool> spec, int pagesize, int pagenummer, string sort, bool order)
        {
            throw new NotImplementedException();
        }

        public int GetSelectionTotal(Func<TEntiteit, bool> spec)
        {
            return GetSelect<TEntiteit>().Count(spec);
        }

        public void AddNew(TEntiteit ent)
        {
            _uow.AddNew(ent);
        }

        public void Remove(TEntiteit ent)
        {
            _uow.Remove(ent);
        }

        public void Update(TEntiteit ent)
        {
            _uow.Attach(ent);
        }

        public void SaveChanges()
        {
            _uow.Commit();
        }
    }
}
