using CiberNiteco.Entities.EF;
using Microsoft.EntityFrameworkCore;

namespace CiberNiteco.Application
{
    public abstract class BaseRepository
    {
        private readonly IDbContextFactory<CiberNitecoDbContext> _factory;

        protected BaseRepository(IDbContextFactory<CiberNitecoDbContext> factory)
        {
            _factory = factory;
        }

        protected CiberNitecoDbContext Create()
        {
            return _factory.CreateDbContext();
        }
    }
}