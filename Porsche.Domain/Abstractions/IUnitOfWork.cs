using Porsche.Domain.Abstractions;

namespace Porsche.Domain.Abstractions;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
    ICarRepository Cars { get; }
    IPorscheCenterRepository Centers { get; }
    IUserCarRepository UsersCars { get; }
    Task SaveAsync();

}