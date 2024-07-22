using CarRepairWorkshops.Domain.Constants;
using Xunit;
using FluentAssertions;

namespace CarRepairWorkshops.Application.Users.Tests
{
    public class CurrentUserTests
    {
        [Theory()]
        [InlineData(UserRoles.WorkshopOwner)]
        [InlineData(UserRoles.Mechanic)]
        public void IsInRole_WithMatchingRole_ShouldReturnTrue(string role)
        {
            var newCurrentUser = new CurrentUser("0", "test@test.com", [UserRoles.WorkshopOwner, UserRoles.Mechanic], null, null);

            var isInRole = newCurrentUser.IsInRole(role);

            isInRole.Should().BeTrue();
        }

        [Fact()]
        public void IsInRole_WithMatchingRole_ShouldReturnFalse()
        {
            var newCurrentUser = new CurrentUser("0", "test@test.com", [UserRoles.WorkshopOwner, UserRoles.Mechanic], null, null);

            var isInRole = newCurrentUser.IsInRole(UserRoles.Admin);

            isInRole.Should().BeFalse();
        }
    }
}