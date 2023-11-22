using eAdvertise.Application.Interfaces.Repositories;
using eAdvertise.Domain.Entities;
using eAdvertise.Infrastructure.Persistence.Contexts;
using eAdvertise.Infrastructure.Persistence.Repository;

namespace eAdvertise.Infrastructure.Persistence.Repositories
{
    public sealed class AdvertiseRepositoryAsync : GenericRepositoryAsync<Advertise>, IAdvertiseRepositoryAsync
    {
        public AdvertiseRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
