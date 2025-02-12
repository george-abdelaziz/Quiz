using Microsoft.AspNetCore.Identity.UI.Services;

namespace Service
{
    public class DummyEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // No email is actually sent.
            return Task.CompletedTask;
        }
    }
}
