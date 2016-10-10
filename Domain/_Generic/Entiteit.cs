using System;

namespace Domain.Generic
{
    public abstract class Entiteit : DomainObject
    {
        public Guid UID { get; protected set; }

        public void NieuwUID()
        {
            UID = Guid.NewGuid();
        }

    }
}
