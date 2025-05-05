using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;

namespace Usuarios.Domain.Abstractions;
    public class Result
    {
        //Creamos un constructor para 
        protected internal Result(bool isSuccess, Error error ){
            if( isSuccess && error != Error.None ){
                throw new InvalidOperationException();
            }

            if(!isSuccess && error == Error.None ){
                throw new InvalidOperationException();
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess {get;}
        public Error Error {get;}
        public bool IsFailur => !IsSuccess;

        public static Result Success() => new Result(true, Error.None);
        public static Result Failur(Error error) => new Result(false,error);

        public static Result<TValue> Success<TValue>(TValue value) => new (value, true, Error.None);
        public static Result<TValue> Failur<TValue>(Error error) => new(default, false, error);

        public static Result<TValue> Create<TValue> (TValue value) 
        => value is not null ?
            Success(value):
            Failur<TValue> (Error.NullValue);

    }


    //Respuestas para tipo comant 
    public class Result<TValue> : Result
    {

        private readonly TValue? _value;
        protected internal Result(TValue? value, bool isSuccess, Error error) : base(isSuccess, error)
        {
            _value = value;
        }

        [NotNull]
        public TValue value => IsSuccess ?
            _value! : throw new InvalidOperationException("El reslutado del operador no esperado");

        //Aplicar el operation para el casteo del TValue
        public static implicit operator Result<TValue>(TValue? value) => Create(value);
    }