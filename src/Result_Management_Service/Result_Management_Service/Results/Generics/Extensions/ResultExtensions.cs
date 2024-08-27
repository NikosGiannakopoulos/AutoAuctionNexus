using Result_Management_Service.Errors;

namespace Result_Management_Service.Results.Generics.Extensions
{
    public static class ResultExtensions
    {
        public static TResult Match<T, TResult>(
            this Result<T> result,
            Func<T, TResult> onSuccess,
            Func<Error, TResult> onFailure)
        {
            return result.IsSucess ? onSuccess(result.Data) : onFailure(result.Error);
        }
    }
}