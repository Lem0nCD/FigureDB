using FigureDB.IRepository;
using FigureDB.IService;
using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FigureDB.IdentityServer.Configure
{
    public class FigureDBProfileService : IProfileService
    {
        private readonly IUserService _userService;

        public FigureDBProfileService(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public virtual async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject?.GetSubjectId();
            if (sub == null) throw new Exception("No sub claim present");

            var user = await _userService.GetUserAsync(Guid.Parse(sub));
            if (user != null)
            {
                List<Claim> claims = new List<Claim>()
                {

                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
                    new Claim(JwtRegisteredClaimNames.GivenName, user.Nickname ?? string.Empty),
                };

                context.AddRequestedClaims(claims);
            }
        }

        public virtual async Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
        }
    }
}
