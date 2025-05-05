using System.Diagnostics.Contracts;
using System.Text.RegularExpressions;
using Usuarios.Domain.Abstractions;

namespace Usuarios.Domain.Usuarios;
    public record CorreoElectronico
    {
        public string Value { get; init;}

        private CorreoElectronico (string value){
            Value = value;
        }

        public static Result<CorreoElectronico> Create(string value){

            if(!EsCorreoValido(value)){
                return Result.Failur<CorreoElectronico>(UsuarioErrores.CorreoElectronicoInvalido);
            }
            return new CorreoElectronico(value);
        }

        public static bool EsCorreoValido(string value){
            const string emailRegex = @"^[a-zA-Z0-9.!#$%$'*+/=?^]";
            if(string.IsNullOrWhiteSpace(value)){
                return false;
            }

            return Regex.Match(value, emailRegex).Success;
        }
    }
