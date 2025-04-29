using Usuarios.Domain.Abstractions;

namespace Usuarios.Domain.Usuarios;

    public class UsuarioErrores
    {
        public static Error CorreoElectronicoInvalido = new (
            "Usuario.CorreoElectronicoInvalido",
            "El correo electrónico no tiene el formato adecuado"
        );

        public static Error NombreUsuarioInvalido = new (
            "Usuario.NombreUsuarioInvalido",
            "El nombre de usuario no tiene el formato adecuado"
        );
    }
