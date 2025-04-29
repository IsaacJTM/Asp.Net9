using MediatR;
using Usuarios.Domain.Abstractions;

namespace Usuarios.Application.Abstractions.Messaging;
    public interface ICommand :IRequest<Result> , IBaseCommand
    {
        
    }
    //Devuleve un result con un valor
    public interface ICommand<TResponse> : IRequest<Result<TResponse>> , IBaseCommand
    {

    }

    //para hacer un testeo mas adelante
    public interface IBaseCommand
    {

    }