
namespace Application.Interfaces.IServices
{
    public interface IFirebaseService
    {
        Task<bool> VerifyPhoneNumberAsync(string phoneNumber, string firebaseToken);
    }
}