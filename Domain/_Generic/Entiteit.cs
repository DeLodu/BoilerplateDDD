using System;

namespace Domain.Generic
{
    public class Entiteit : DomainObject
    {
        public Guid UID { get; private set; }

        public void NieuwUID()
        {
            UID = Guid.NewGuid();
        }

    }
}
