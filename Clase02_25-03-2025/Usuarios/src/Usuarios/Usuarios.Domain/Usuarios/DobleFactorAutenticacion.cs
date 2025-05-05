using Usuarios.Domain.Abstractions;
using Usuarios.Domain.Shared;

namespace Usuarios.Domain.Usuarios;
    public class DobleFactorAutenticacion : Entity
    {
        public Guid UsuarioId{get ; private set;}
        
        public TipoDobleFactor Tipo {get ; private set;}
        public string Codigo {get; private set;}
        public Estados Estado{get; private set;}
        public DateTime FechaCreacion{get; private set;}




        public DobleFactorAutenticacion(
            Guid id,
            Guid usuarioId,
            TipoDobleFactor tipo,
            string codigo,
            DateTime fechaCreacion
            
            ) : base(id)
        {
            UsuarioId = usuarioId;
            Tipo = tipo;
            Codigo = codigo;
            Estado = Estados.Activo;
            FechaCreacion = fechaCreacion;

        }

        public static Result<DobleFactorAutenticacion> Registrar(
            Guid usuarioId,
            TipoDobleFactor tipo,
            string codigo,
            DateTime fechaCreacion
        )
        {
            return  Result.Success(new DobleFactorAutenticacion
            (Guid.NewGuid(),
            usuarioId,
            tipo,
            codigo,
            fechaCreacion));
        }

        public void Desactivar()
        {
            Estado = Estados.Inactivo;
        }
    }
