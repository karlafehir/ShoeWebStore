using Microsoft.AspNetCore.Identity.UI.Services;

namespace ShoeWebStore.Utility;

public class EmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        //slanje maila
        return Task.CompletedTask;
    }
}