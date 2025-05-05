using Usuarios.Domain.Abstractions;

namespace Usuarios.Domain.Roles;
    public static class RolErrores
    {
        public static Error NoEncontrado = new
        (
            "RolErrores.NoEncontrado",
            "El rol no fue encontrado"
        );
    }
