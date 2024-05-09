using Porsche.Domain.Dtos;

namespace Porsche.Application.Abstractions;

public interface IAdminService
{
    Task ChangeUserRole(ChangeRoleDto changeRoleDto);
}