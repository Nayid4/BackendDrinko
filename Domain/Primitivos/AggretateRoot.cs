using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitivos
{
    public abstract class AggretateRoot
    {
        private readonly List<DomainEvent> _domainEvent = new();

        public ICollection<DomainEvent> GetDomainEvents() => _domainEvent;

        protected void Raise(DomainEvent domainEvent)
        {
            _domainEvent.Add(domainEvent);
        }

    }
}
