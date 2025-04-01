
using Usuarios.Domain.Abstractions;

namespace Usuarios.Domain.Usuarios;
    public class Usuario : Entity
    {   
        public Usuario (Guid id ) : base ( id ){

        }

        public string NombrePersona {get;set;}
        public string ApellidoPaterno {get; set;}
        public string ApellidoMaterno {get; set;}
        public string Password {get; set;}
        public string CorreoElectonico {get; set;}

        public Direccion? Direccion {get; set;}


        
    }
