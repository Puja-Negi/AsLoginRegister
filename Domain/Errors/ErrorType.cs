namespace Domain.Errors
{
    public class ErrorType
    {
        public ErrorType Type { get; }

        public ErrorType(ErrorType type)
        {
            Type = type;
        }
        public static ErrorType DuplicatePhoneNumber { get; set; }
        public static ErrorType InvalidCredentials { get; set; }
    }
}
