﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairWorkshops.Application.Users
{
    public class UserContext(IHttpContextAccessor contextAccessor) : IUserContext
    {
        public CurrentUser? GetCurrentUser()
        {
            var user = contextAccessor?.HttpContext?.User;
            if (user == null)
            {
                throw new InvalidOperationException("User context not present");
            }

            if ((user.Identity == null) || !user.Identity.IsAuthenticated)
            {
                return null;
            }

            var userId = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
            var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role)!.Select(c => c.Value);
            var nationality = user.FindFirst(c => c.Type == "Nationality")?.Value;
            var dateOfBirthString = user.FindFirst(c => c.Type == "DateOfBirth")?.Value;
            var dateOfBirth = dateOfBirthString == null ? (DateOnly?)null : DateOnly.ParseExact(dateOfBirthString, "yyyy-MM-dd");

            return new CurrentUser(userId, email, roles, nationality, dateOfBirth);

        }
    }
}
