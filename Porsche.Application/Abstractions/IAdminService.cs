namespace Porsche.Application.Abstractions;

public interface IAdminService
{
    Task ChangeUserRole(Guid id);
}