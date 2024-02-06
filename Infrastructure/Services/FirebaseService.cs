using Application.Interfaces.IServices;
using FirebaseAdmin;
using FirebaseAdmin.Auth;

namespace Infrastructure.Services
{
    public class FirebaseService : IFirebaseService
    {
        private readonly FirebaseApp _firebaseApp;

        public FirebaseService(FirebaseApp firebaseApp)
        {
            _firebaseApp = firebaseApp;
        }


        public async Task<bool> VerifyPhoneNumberAsync(string phoneNumber, string firebaseToken)
        {
            try
            {
                var auth = FirebaseAuth.GetAuth(_firebaseApp);
                var decodedToken = await auth.VerifyIdTokenAsync(firebaseToken);

                //To ensure provided phoneNumber matches the one in decoded token
                if (decodedToken.Claims.ContainsKey("PhoneNumber"))
                {
                    var decodedPhoneNumber = decodedToken.Claims["PhoneNumber"].ToString();
                    if (decodedPhoneNumber == phoneNumber)
                    {
                    return true;
                    }
                }
                return false;
            }
            catch (FirebaseAuthException)
            {
                return false;
            }
        }
    }
}