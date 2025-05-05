namespace Usuarios.Application.Usuarios.CrearUsuario;
    internal sealed class CrearUsuarioCommandHandler : ICommandHandler<CrearUsuarioCommandHandler, Guid>
    {
        //Esto es inyección de dependencias --- Abstracciones. Utilizamos abstracciones para nuestor caso de USO
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IRolRepository _rolRepository;
        private readonly NombreUsuarioService _nombreUsuarioService;

        public CrearUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider, IRolRepository rolRepository, NombreUsuarioService nombreUsuarioService){
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
            _dateTimeProvider = dateTimeProvider;
            _rolRepository = rolRepository;
            _nombreUsuarioService = nombreUsuarioService;
        }

//Esta va hacer una operación asíncrona. -- Todo se hace a travez de abstracciones. Creación del Usuario.
        public async Task<Result<Guid> Handle (CrearUsuarioCommand request, CancellationToken cancellationToken){

            var rol = await _rolRepository.GetByNameAsync(request.Rol, cancellationToken);
            if(rol is null)
            {
                return Result.Failure<Guid>(RolErrores.NoEncontrado);
            }
            var usuario = Usuario.Create(
                request.NombrePersona,
                request.ApellidoPaterno,
                request.ApellidoMaterno,
                Password.Create(request.Password),
                request.FechaNacimiento,
                CorreoElectronico.Create(request.CorreoElectronico).Value,
                new Direccion(
                    request.Pais,
                    request.Departamento,
                    request.Distrito,
                    request.Calle
                ),
                _dateTimeProvider.CurrentTime.ToUniversalTime(),
                rol.Id,
                _nombreUsuarioService
            );
            -_usuarioRepository.Add(usuario.Value);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success(usuario.Value.Id);
        }
    }
