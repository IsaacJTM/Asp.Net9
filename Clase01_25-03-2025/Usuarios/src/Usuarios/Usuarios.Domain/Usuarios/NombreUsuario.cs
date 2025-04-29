using System.ComponentModel;
using Usuarios.Domain.Abstractions;

namespace Usuarios.Domain.Usuarios;
    public record NombreUsuario
    {
        public string Value { get; init; }

        private NombreUsuario(string value){
            Value = value;
        }

        public static Result<NombreUsuario> Create(string value){
            if(string.IsNullOrWhiteSpace(value)){
                return Result.Failur<NombreUsuario>(UsuarioErrores.NombreUsuarioInvalido);
            }
            return new NombreUsuario(value);
        }
    }
