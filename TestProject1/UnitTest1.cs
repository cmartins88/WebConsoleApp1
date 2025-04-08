using WebApplication1;
using WebApplication1.Models;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldMapPTtoPortugalOnCountryProperty()
        {
            User user = new User();
            user.Name = "Carlos";
            user.Country = "PT";

            User sut = UserManager.mapUserCountry(user);

            Assert.Equal("Portugal", sut.Country);
        }
    }
}