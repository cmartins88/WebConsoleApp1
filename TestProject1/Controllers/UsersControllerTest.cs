using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.EntityFrameworkCore;
using WebApplication1.Controllers;
using WebApplication1.Data;
using WebApplication1.Models;

namespace TestProject1.Controllers
{
    public class UsersControllerTest
    {
        [Fact]
        public void ShouldGetAllUsers()
        {
            var mockRepo = new Mock<APIContext>();
            mockRepo.Setup(u => u.Users).ReturnsDbSet(GetTestUsers());

            var expected = GetTestUsers();
            var sut = new UsersController(mockRepo.Object).Details();

            Assert.NotNull(sut);
            Assert.IsType<ActionResult<IEnumerable<User>>>(sut);
            Assert.True(expected.SequenceEqual(sut.Value));
        }

        [Fact]
        public void ShouldGetAllUsersAndValidateEmail()
        {
            var mockRepo = new Mock<APIContext>();
            mockRepo.Setup(u => u.Users).ReturnsDbSet(GetTestUsers());

            var expected = "carlos@gmail.com";
            var sut = new UsersController(mockRepo.Object).Details().Value?.FirstOrDefault()?.Email;

            Assert.NotNull(sut);
            Assert.Equal(expected, sut);
        }

        private IEnumerable<User> GetTestUsers()
        {
            var users = new List<User>()
            {
                new User() { Email = "carlos@gmail.com" }
            };
            return users;
        }
    }
}
