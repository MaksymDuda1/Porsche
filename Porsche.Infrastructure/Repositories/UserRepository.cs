using Porsche.Domain.Abstractions;
using Porsche.Domain.Entities;

namespace Porsche.Infrastructure.Repositories;

public class UserRepository(PorscheDbContext context)
    :BaseRepository<UserEntity>(context), IUserRepository
{
    
}