using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using WebApplication1;
using WebApplication1.Controllers;
using WebApplication1.Data;
using WebApplication1.Models;
using Xunit.Sdk;

namespace TestProject1
{
    public class UserManagerUnitTest
    {
        private readonly string COUNTRY;

        // setup
        public UserManagerUnitTest()
        {
            COUNTRY = "Portugal";
        }

        // teardown
        public void Dispose()
        {
            // Dispose here
        }


        [Fact]
        public void ShouldMapPTtoPortugalOnCountryProperty1()
        {
            User user = new User();
            user.Name = "Carlos";
            user.Country = "PT";

            User sut = UserManager.mapUserCountry(user);

            Assert.Equal(COUNTRY, sut.Country);
        }

        [Fact]
        public void ShouldMapPTtoPortugalOnCountryProperty2()
        {
            User user = new User();
            user.Name = "Carlos";
            user.Country = "pt-pt";

            User sut = UserManager.mapUserCountry(user);

            Assert.Equal(COUNTRY, sut.Country);
        }

        [Fact]
        public void ShouldMapPTtoPortugalOnCountryProperty3()
        {
            User user = new User();
            user.Name = "Carlos";
            user.Country = "Pt";

            User sut = UserManager.mapUserCountry(user);

            Assert.Equal(COUNTRY, sut.Country);
            Assert.False(string.IsNullOrEmpty(sut.Country));
        }

        [Fact]
        public void ShouldThrowsExceptionWhenMapNonExistsCountryOnCountryProperty1()
        {
            User user = new User();
            user.Name = "Carlos";
            user.Country = "Es";

            Action sut = () => UserManager.mapUserCountry(user);
            Assert.Throws<KeyNotFoundException>(sut);
        }

        [Fact]
        public void ShouldThrowsExceptionWhenMapNonExistsCountryOnCountryProperty2()
        {
            User user = new User();
            user.Name = "Carlos";
            user.Country = "FR";

            Action sut = () => UserManager.mapUserCountry(user);
            Assert.Throws<KeyNotFoundException>(sut);
        }

        [Fact]
        public void ShouldThrowsExceptionWhenMapNonExistsCountryOnCountryProperty3()
        {
            User user = new User();
            user.Name = "Carlos";
            user.Country = "TB";

            Action sut = () => UserManager.mapUserCountry(user);
            Assert.Throws<KeyNotFoundException>(sut);
        }

        [Fact]
        public void ShouldThrowsExceptionWhenMapNonExistsCountryOnCountryProperty5()
        {
            User user = new User();
            user.Name = "Carlos";
            user.Country = "";

            Action sut = () => UserManager.mapUserCountry(user);
            Assert.Throws<KeyNotFoundException>(sut);
        }

        [Fact]
        public void ShouldThrowsExceptionWhenMapNonExistsCountryOnCountryProperty6()
        {
            User user = new User();
            user.Name = "Carlos";
            user.Country = null;

            Action sut = () => UserManager.mapUserCountry(user);
            Assert.Throws<ArgumentNullException>(sut);
        }


        [Fact]
        public void ShouldThrowsExceptionWhenMapNonExistsCountryOnCountryProperty7()
        {
            User user = new User();
            user.Name = "Carlos@";
            user.Country = null;

            Action sut = () => UserManager.mapUserCountry(user);
            ArgumentException ex = Assert.Throws<ArgumentException>(sut);
            Assert.Equal("The first name cannot contain an @", ex.Message);
        }
    }
}