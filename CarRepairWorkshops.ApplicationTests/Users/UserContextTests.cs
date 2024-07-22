using Xunit;
using Moq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using CarRepairWorkshops.Domain.Constants;
using Xunit.Sdk;
using FluentAssertions;




namespace CarRepairWorkshops.Application.Users.Tests
{
    public class UserContextTests
    {
        [Fact()]
        public void GetCurrentUserTest_WithAutenthicatedUser_ShouldReturnCurrentUser()
        {
            var dateOfBirth = new DateOnly(1990, 2, 1);

            var httpContextAccesorMock = new Mock<IHttpContextAccessor>();
            var claims = new List<Claim>()
            {
                new(ClaimTypes.NameIdentifier, "0"),
                new(ClaimTypes.Email, "test@test.com"),
                new(ClaimTypes.Role, UserRoles.Admin),
                new(ClaimTypes.Role, UserRoles.WorkshopOwner),
                new("Nationality", "New Zealand"),
                new("DateOfBirth", dateOfBirth.ToString("yyyy-MM-dd")),


            }; 

            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "Test"));

            httpContextAccesorMock.Setup(x => x.HttpContext).Returns(new DefaultHttpContext()
            {
                User = user
            });

            var userContext = new UserContext(httpContextAccesorMock.Object);

            //act

            var currentUser = userContext.GetCurrentUser();

            currentUser.Should().NotBeNull();
            currentUser.Id.Should().Be("0");
        }

        [Fact()]
        public void GetCurrentUserTest_WithAutenthicatedUser_ThrowsInvalidOperationException()
        {
            var httpContextAccesorMock = new Mock<IHttpContextAccessor>();


            httpContextAccesorMock.Setup(x => x.HttpContext).Returns((HttpContext)null);
            

            var userContext = new UserContext(httpContextAccesorMock.Object);

            //act

            Action action = () => userContext.GetCurrentUser();

            action.Should().Throw<InvalidOperationException>();
                
        }
    }
}