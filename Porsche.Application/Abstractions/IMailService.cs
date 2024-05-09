namespace Porsche.Application.Abstractions;

public interface IMailService
{
    Task SendEmailToManager(string identityCode, string userEmail);
    Task SendEmailToUser(string userEmail, string username);
}