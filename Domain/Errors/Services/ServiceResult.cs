using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Errors.Services
{
    public class ServiceResult <T>
    {
        public bool isSuccess { get; }
       // public string errorMessage { get; }
        public T data  { get; }
        //public ErrorType type { get; }
        public ErrorResponse errorResponse { get; }

        public ServiceResult(bool isSuccess, T data, ErrorResponse errorResponse)
        {
            this.isSuccess = isSuccess;
            this.data = data ;
            this.errorResponse = errorResponse;
        }


        public static ServiceResult<T> Success(T data )
        {
            return new ServiceResult<T>(true, data, null);
        }

        public static ServiceResult<T> Failure(ErrorResponse errorResponse)
        {
            return new ServiceResult<T>(false, default, errorResponse);
        }

       
    }
}
