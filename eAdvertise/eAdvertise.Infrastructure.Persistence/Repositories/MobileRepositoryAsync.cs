using eAdvertise.Application.Interfaces.Repositories;
using eAdvertise.Domain.Entities;
using eAdvertise.Infrastructure.Persistence.Contexts;
using eAdvertise.Infrastructure.Persistence.Repository;

namespace eAdvertise.Infrastructure.Persistence.Repositories
{
    public sealed class MobileRepositoryAsync : GenericRepositoryAsync<Mobile>, IMobileRepositoryAsync
    {
        public MobileRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
