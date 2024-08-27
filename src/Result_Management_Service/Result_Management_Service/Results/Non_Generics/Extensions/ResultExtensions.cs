using Result_Management_Service.Errors;

namespace Result_Management_Service.Results.Non_Generics.Extensions
{
    public static class ResultExtensions
    {
        public static TResult Match<TResult>(
            this Result result,
            Func<TResult> onSuccess,
            Func<Error, TResult> onFailure)
        {
            return result.IsSucess ? onSuccess() : onFailure(result.Error);
        }
    }
}