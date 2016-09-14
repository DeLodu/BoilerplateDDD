using System;
using System.Collections.Generic;
using Domain.Generic;

namespace Domain.DependencyContracts
{
    public interface IRepository<TEntiteit>
        where TEntiteit : Entiteit
    {
        TEntiteit GetByUid(Guid uID);

        TEntiteit GetGraphByUid(Guid uID);

        IEnumerable<TEntiteit> GetSelection(Func<TEntiteit, bool> spec);

        IEnumerable<TEntiteit> GetPageSelection(Func<TEntiteit, bool> spec, int pagesize, int pagenummer, string sort, bool order);

        int GetSelectionTotal(Func<TEntiteit, bool> spec);

        void AddNew(TEntiteit ent);

        void Remove(TEntiteit ent);

        void Update(TEntiteit ent);

        void SaveChanges();
    }
}
