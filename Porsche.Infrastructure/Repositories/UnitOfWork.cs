using Porsche.Domain.Abstractions;

namespace Porsche.Infrastructure.Repositories;

public class UnitOfWork(
    PorscheDbContext context,
    Lazy<IUserRepository> userRepository,
    Lazy<ICarRepository> carRepository,
    Lazy<IPorscheCenterRepository> porscheCenterRepository,
    Lazy<IUserCarRepository> userCarRepository
   ) : IUnitOfWork
{
    public IUserRepository Users => userRepository.Value;
    public ICarRepository Cars => carRepository.Value;
    public IPorscheCenterRepository Centers => porscheCenterRepository.Value;
    public IUserCarRepository UsersCars => userCarRepository.Value;
    public async Task SaveAsync() => await  context.SaveChangesAsync();

}