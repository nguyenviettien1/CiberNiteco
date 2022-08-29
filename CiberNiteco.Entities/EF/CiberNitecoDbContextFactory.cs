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
            optionBuilder.UseSqlServer("Data Source=34.126.166.25;Initial Catalog=ApatekDms;User ID=sa;Password=12345aA@;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30");
            return new CiberNitecoDbContext(optionBuilder.Options);
        }
    }
}