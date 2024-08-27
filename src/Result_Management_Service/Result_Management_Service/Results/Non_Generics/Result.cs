using Result_Management_Service.Errors;

namespace Result_Management_Service.Results.Non_Generics
{
    public class Result
    {
        public bool IsSucess { get; }
        public bool IsFailure => !IsSucess;
        public Error Error { get; }

        private Result(bool isSucess, Error error)
        {
            if (isSucess && error != Error.None || !isSucess && error == Error.None)
            {
                throw new ArgumentException("Invalid error", nameof(error));
            }

            IsSucess = isSucess;
            Error = error;
        }

        public static Result Success() => new(true, Error.None);

        public static Result Failure(Error error) => new(false, error);
    }
}