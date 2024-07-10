using Result_Manager.Errors;

namespace Result_Manager.Results.Generics.Extensions
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