using System;

namespace SupperSlonicDomain.Models.Account
{
    public class UserVerification
    {
        public User User { get; set; }

        public Guid VerifyEmailCode { get; set; }
    }
}