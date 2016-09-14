using System;
using Domain.Generic;

namespace Domain.DependencyContracts
{
    public interface IRepository<TEntiteit>
        where TEntiteit : Entiteit
    {
        
    }
}
