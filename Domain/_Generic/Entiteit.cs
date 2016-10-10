using System;

namespace Domain.Generic
{
    public class Entiteit : DomainObject
    {
        public Guid UID { get; protected set; }

        public void NieuwUID()
        {
            UID = Guid.NewGuid();
        }

    }
}
