using FigureDB.Model.Context;
using FigureDB.Model.Entities;
using FigureDB.Repository;
using FigureDB.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace FigureDB.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public const string constr = "Server=.;Database=FigureDB;User Id=sa;Password=sa;";
        public static DbContextOptions<MainContext> CreateDbContextOptions(string databaseName)
        {
            var serviceProvider = new ServiceCollection().
                AddEntityFrameworkSqlServer()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<MainContext>();
            builder.UseSqlServer(databaseName)
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }
        //[TestMethod]
        //public async Task CreateUser()
        //{
        //    var context = new MainContext(CreateDbContextOptions(constr));
        //    var u = new UserService(new GenericRepository<User,Guid>(context),new UnitOfWork(context));
        //    bool b = await u.CreateUserAsync();
        //    Assert.IsTrue(b);
        //}

        //[TestMethod]
        //public async Task QueryUser()
        //{
        //    var context = new MainContext(CreateDbContextOptions(constr));
        //    var u = new UserService(new GenericRepository<User, Guid>(context), new UnitOfWork(context));
        //    var b = await u.GetUserAsync(Guid.Parse("357CAFEE-6110-4195-B280-DC1101CED232"));
        //    Assert.IsNotNull(b);
        //}
    }
}
