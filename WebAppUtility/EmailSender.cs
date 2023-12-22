using Microsoft.AspNetCore.Identity.UI.Services;

namespace WebAppUtility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //Logic to send Email
            return Task.CompletedTask;
        }
    }
}
