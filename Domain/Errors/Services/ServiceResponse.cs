namespace Domain.Errors.Services
{
    public class ServiceResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public string Error { get; set; }
        public ServiceResponse(bool isSuccess, T? data, string? error)
        {
            this.IsSuccess = isSuccess;
            this.Data = data;
            this.Error = error;
        }
    }
}
  