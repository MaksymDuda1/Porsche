using Porsche.Domain.Abstractions;
using Porsche.Domain.Entities;

namespace Porsche.Infrastructure.Repositories;

public class CarRepository(PorscheDbContext context)
    :BaseRepository<CarEntity>(context), ICarRepository
{
    
}