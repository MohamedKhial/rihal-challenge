using Microsoft.AspNetCore.Http;
using rihal.challenge.Application.Contracts.Services;
using rihal.challenge.Application.Models.DTOs.Authentication.Identity;
using System;
using System.Security.Claims;

namespace rihal.challenge.WebApi.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public LoggedInUser GetLoggedInUser()
        {
            ClaimsPrincipal currentUser = _httpContextAccessor.HttpContext.User;
            string username = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            string userId = currentUser.FindFirst("UserId").Value;

            return new LoggedInUser(Guid.Parse(userId), username);
        }
    }
}
