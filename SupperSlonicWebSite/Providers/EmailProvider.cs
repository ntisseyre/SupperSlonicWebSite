using Mvc.Mailer;
using SupperSlonicDomain.Models.Account;
using SupperSlonicWebSite.Models.Email;
using SupperSlonicWebSite.Resources;
using System;
using System.Threading.Tasks;

namespace SupperSlonicWebSite.Providers
{
    public class EmailProvider : MailerBase
    {
        private const string MyEmail = "natalia.a.zelenskaya@gmail.com";

        public EmailProvider()
        {
            base.MasterName = "_MailLayout";
        }

        public void SendHelpMeAsync(HelpMe model)
        {
            ViewData.Model = model;
            var mailMessage = Populate(x =>
            {
                x.Subject = Emails.HelpMe;
                x.ViewName = "HelpMe";
                x.To.Add(MyEmail);
            });

            Task.Factory.StartNew(() => mailMessage.Send());
        }

        public void SendVerificationCodesAsync(UserVerification userVerification)
        {
            if (userVerification == null)
                throw new ArgumentNullException("userVerification");

            ViewData.Model = userVerification;
            var mailMessage = Populate(x =>
            {
                x.Subject = Emails.RegistrationConfirmation;
                x.ViewName = "RegistrationConfirmation";
                x.To.Add(userVerification.User.Email);
            });

            Task.Factory.StartNew(() => mailMessage.Send());
        }

        public void SendConfirmedAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            ViewData.Model = user;
            var mailMessage = Populate(x =>
            {
                x.Subject = Emails.RegistrationConfirmed;
                x.ViewName = "RegistrationConfirmed";
                x.To.Add(user.Email);
            });

            Task.Factory.StartNew(() => mailMessage.Send());
        }

        public void SendDeleteConfirmationAsync(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user");

            ViewData.Model = user;
            var mailMessage = Populate(x =>
            {
                x.Subject = Emails.DeleteConfirmation;
                x.ViewName = "DeleteConfirmation";
                x.To.Add(user.Email);
            });

            Task.Factory.StartNew(() => mailMessage.Send());
        }
    }
}