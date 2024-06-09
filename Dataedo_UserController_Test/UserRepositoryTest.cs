using Dataedo_UserController.Models;
using Dataedo_UserController.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataedo_UserController_Test
{
    public class UserRepositoryTest
    {
        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public async Task AddUserAsync_ShouldAddUser()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new UserRepository(context);
            var user = new User { Id = 1U, Login = "testuser" };

            // Act
            await repository.AddAsync(user);
            var result = await context.Users.FindAsync(1U);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("testuser", result.Login);
        }

        [Fact]
        public async Task DeleteUserAsync_ShouldDeleteUser()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var repository = new UserRepository(context);
            var user = new User { Id = 1U, Login = "testuser" };

            await repository.AddAsync(user);

            // Act
            await repository.DeleteAsync(user.Id);
            var result = await context.Users.FindAsync(1U);

            // Assert
            Assert.Null(result);
        }
    }
}
