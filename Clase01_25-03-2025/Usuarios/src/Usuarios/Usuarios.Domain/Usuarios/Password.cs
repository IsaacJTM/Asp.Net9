namespace Usuarios.Domain.Usuarios;
    public record Password
    {
        public string Value {get;set;}
        
        private Password (string value){
            Value = value;
        }

        public static Password Create(string value){
            if(string.IsNullOrWhiteSpace(value) || value.Length < 8){
                throw new ArgumentException("Formato incorrecto ", nameof(value));
            }

            return new Password(value);
        }
        
    }
