
using Usuarios.Domain.Abstractions;
using Usuarios.Domain.Roles;
using Usuarios.Domain.Shared;

namespace Usuarios.Domain.Usuarios;
    public class Usuario : Entity
    {   
        public readonly List<DobleFactorAutenticacion> _dobleFactorAutenticacions = new ();

        private Usuario(
            Guid id,
            string nombrePersona,
            string apellidoPaterno,
            string apellidoMaterno,
            Password password,
            CorreoElectronico correoElectronico,
            NombreUsuario nombreUsuario,
            DateTime fechaNacimiento,
            Direccion direccion,
            Estados estado,
            DateTime fechaUltimoCambio,
            Guid rolId
            )
            : base ( id )
        {
            NombrePersona = nombrePersona;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            _Password = password;
            FechaNacimiento = fechaNacimiento;
            NombreUsuario = nombreUsuario;
            CorreoElectonico = correoElectronico;
            Direccion = direccion;
            Estado = estado;
            FechaUltimoCambio = fechaUltimoCambio;
            RolId = rolId;
        }

        public string NombrePersona {get;private set;}
        public string ApellidoPaterno {get; private set;}
        public string ApellidoMaterno {get; private set;}
        public Password? _Password {get; private set;}
        public CorreoElectronico? CorreoElectonico {get; private set;}
        public NombreUsuario? NombreUsuario {get; private set;}

        public DateTime FechaNacimiento {get; private set;}
        public Direccion? Direccion {get; private set;}

        public Estados Estado {get; private set;}
        public DateTime FechaUltimoCambio {get; private set;}

        public Rol? Rol {get; private set;}

        public Guid RolId {get; private set;}

        public IReadOnlyList<DobleFactorAutenticacion> DobleFactorAutenticacions => _dobleFactorAutenticacions;

        public  static Result<Usuario> Create(
            string nombrePersona,
            string apellidoPaterno,
            string apellidoMaterno,
            Password password,
            CorreoElectronico correoElectronico,
            DateTime fechaNacimiento,
            Direccion direccion,
            DateTime fechaUltimoCambio,
            Guid rolId,
            NombreUsuarioServices nombreUsuarioServices
        ){

            var nombreUsuarioResult = nombreUsuarioServices.GenerarNombreUsuarios(nombrePersona,apellidoPaterno);
            return Result.Success(
             new Usuario(
             id,
             nombrePersona,
             apellidoPaterno,
             apellidoMaterno,
             password,
             correoElectronico,
             direccion,
             fechaNacimiento,
             rolId,
             )
            )
        }
    }
