using Result_Manager.Errors;

namespace Result_Manager.Results.Generics
{
    public class Result<T>
    {
        public bool IsSucess { get; }
        public bool IsFailure => !IsSucess;
        public T Data { get; }
        public Error Error { get; }

        private Result(bool isSucess, T data, Error error)
        {
            if (isSucess && error != Error.None || !isSucess && error == Error.None)
            {
                throw new ArgumentException("Invalid error", nameof(error));
            }

            IsSucess = isSucess;
            Data = data;
            Error = error;
        }

        public static Result<T> Success(T data) => new(true, data, Error.None);

        public static Result<T> Failure(Error error) => new(false, default, error);
    }
}