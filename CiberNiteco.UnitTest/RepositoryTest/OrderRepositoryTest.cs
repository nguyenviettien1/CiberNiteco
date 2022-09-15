using System;
using System.Threading.Tasks;
using CiberNiteco.Core.Repository;
using CiberNiteco.Entities.EF;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Xunit;
using Assert = Xunit.Assert;

namespace CiberNiteco.UnitTest.RepositoryTest
{
    public class OrderRepositoryTest
    {
        private CiberNitecoDbContext _context;
        private OrderRepository _orderRepository;

        [SetUp]
        public void Setup()
        {
            var dbContextOptions = new DbContextOptionsBuilder<CiberNitecoDbContext>().UseSqlServer(
                "Server=.;Database=CiberNiteco;User ID=sa;Password=yourStrong(!)Password;Encrypt=False;Trusted_Connection=False");
            _context = new CiberNitecoDbContext(dbContextOptions.Options);
            _context.Database.EnsureCreated();
            _orderRepository = new OrderRepository(_context);
        }

        [Test]
        public void TestDown()
        {
            _context.Database.EnsureDeleted();
        }
        [Test]
        public async Task GetAllOrders()
        {
            //Act
            var items = await _orderRepository.GetAllOrder();

            //Assert
            Assert.Equal(5, items.Count);
        }
        
    }
}