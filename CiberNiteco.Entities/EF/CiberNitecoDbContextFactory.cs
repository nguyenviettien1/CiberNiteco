using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CiberNiteco.Entities.EF
{
    public class CiberNitecoDbContextFactory: IDesignTimeDbContextFactory<CiberNitecoDbContext>
    {
        public CiberNitecoDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<CiberNitecoDbContext>();
            optionBuilder.UseSqlServer("Data Source=.;Initial Catalog=CiberNiteco;User ID=sa;Password=yourStrong(!)Password;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30");
            return new CiberNitecoDbContext(optionBuilder.Options);
        }
    }
}