using System;
using Domain.DependencyContracts;

namespace Domain.ApplicationModule.Logger
{
    public interface ILogItemRepository: IRepository<LogItem>
    {
    }
}
