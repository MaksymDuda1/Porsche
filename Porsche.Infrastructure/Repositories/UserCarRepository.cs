using Porsche.Domain.Abstractions;
using Porsche.Domain.Entities;

namespace Porsche.Infrastructure.Repositories;

public class UserCarRepository(PorscheDbContext context)
    :BaseRepository<UserCarEntity>(context), IUserCarRepository
{
    
}