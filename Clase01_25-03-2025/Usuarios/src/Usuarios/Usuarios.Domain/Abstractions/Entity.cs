

namespace Usuarios.Domain.Abstractions;
    public abstract class Entity
    {
        private readonly List<IDomainEvent> _domainEvents = new();

        //inyectamos en el constructor 
        public Entity (Guid id){
            Id = id;
        }
        public Guid Id {get; init;}

        //Para el manejo de eventos de dominio se creará 3 métodos (Listar, Agregar y Eliminar)

        //Agregar
        public void RaiseDomainEvent(IDomainEvent domainEvent){
            _domainEvents.Add(domainEvent);
        }

        //Limpiar 
        public void ClearDomainEvent(IDomainEvent domainEvent){
            _domainEvents.Clear();
        }

        public IReadOnlyList<IDomainEvent> GetDomainEvent() {
            return _domainEvents.ToList();
        }
    }

