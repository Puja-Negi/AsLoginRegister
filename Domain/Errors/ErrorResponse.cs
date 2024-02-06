namespace Domain.Errors
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string? Title { get; set; }
        public string Message { get; set; }

        public ErrorType Type { get; set; }

        public ErrorResponse(int statusCode, string title, string message, ErrorType type)
        {
            StatusCode = statusCode;
            Title = title;
            Message = message;
            Type = type;

        }
        public static ErrorResponse DuplicatePhoneNumber()
        {
            int statusCode = 400;
            string title = "Bad Request";
            string message = "PhoneNumber is already in use.";
            ErrorType type = ErrorType.DuplicatePhoneNumber;

            return new ErrorResponse(statusCode, title, message, type);
        }

        public static ErrorResponse InvalidPhoneNumber()
        {
            int statusCode = 400;
            string title = "Bad Request";
            string message = "User with given phone number doesn't exists.";
            ErrorType type = ErrorType.InvalidCredentials;

            return new ErrorResponse(statusCode, title, message, type);
        }

        public static ErrorResponse InvalidPassword()
        {
            int statusCode = 400;
            string title = "Bad Request";
            string message = "Invalid password.";
            ErrorType type = ErrorType.InvalidCredentials;

            return new ErrorResponse(statusCode, title, message, type);
        }

    }
}
