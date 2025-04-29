using System.Reflection.Metadata;
using Usuarios.Domain.Abstractions;

namespace Usuarios.Domain.Usuarios;
    public class NombreUsuarioServices
    {
        public Result<NombreUsuario> GenerarNombreUsuarios(
            string nombre,
            string apellido
        )
        {
            var nombreUsuario = $"{nombre.Substring(0,1)}.{apellido.Trim()}".ToUpper();
            return NombreUsuario.Create(nombreUsuario);
        }
    }
