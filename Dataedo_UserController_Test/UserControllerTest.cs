using Dataedo_UserController.Controllers;
using Dataedo_UserController.Persistence;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Dataedo_UserController_Test
{
    public class UserControllerTest
    {
        [Fact]
        public async Task Delete_ReturnsOkResult_WhenUserExists()
        {
            // Arrange
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.DeleteAsync(It.IsAny<uint>())).ReturnsAsync(1);
            var controller = new UserController(mockRepo.Object);

            // Act
            var result = await controller.Delete(1);

            // Assert
            var okResult = Assert.IsType<OkResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task Delete_ReturnsNotFoundResult_WhenUserDoesNotExist()
        {
            // Arrange
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(repo => repo.DeleteAsync(It.IsAny<uint>())).ReturnsAsync(0);
            var controller = new UserController(mockRepo.Object);

            // Act
            var result = await controller.Delete(1);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }
    }
}
