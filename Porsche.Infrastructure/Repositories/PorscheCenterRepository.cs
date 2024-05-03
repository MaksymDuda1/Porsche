using Porsche.Domain.Abstractions;
using Porsche.Domain.Entities;

namespace Porsche.Infrastructure.Repositories;

public class PorscheCenterRepository(PorscheDbContext context)
    :BaseRepository<PorscheCenterEntity>(context),IPorscheCenterRepository
{
    
}