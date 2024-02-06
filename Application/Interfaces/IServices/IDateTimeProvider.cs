namespace AutoBooking.Application.Users.IServices
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}