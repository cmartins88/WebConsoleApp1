using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using WebApplication1;
using WebApplication1.Models;

namespace IntegrationTestProject
{
    public class IntegrationTest1 : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _applicationFactory;

        public IntegrationTest1(WebApplicationFactory<Program> applicationFactory)
        {
            _applicationFactory = applicationFactory;
        }

        [Theory]
        [InlineData("/api/users")]
        public async void ShouldGetUsersTest(string url)
        {
            // Arrange
            var client = _applicationFactory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();                     // Status Code 200-299

            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());

            var sut = await response.Content.ReadAsStringAsync();

            Assert.NotEmpty(sut);

            IList<User> user = JsonSerializer.Deserialize<User[]>(sut);

            Assert.NotNull(user);
            Assert.True(user.Count() > 0);
        }
    }
}