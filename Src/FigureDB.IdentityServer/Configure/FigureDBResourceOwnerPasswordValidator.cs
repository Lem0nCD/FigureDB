using FigureDB.IRepository;
using FigureDB.IService;
using FigureDB.Model.Entities;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FigureDB.IdentityServer.Configure
{
    public class FigureDBResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUserIdentityService _userIdentityService;
        private readonly IUserRepository _userRepository;

        public FigureDBResourceOwnerPasswordValidator(IUserIdentityService userIdentityService, IUserRepository userRepository)
        {
            _userIdentityService = userIdentityService ?? throw new ArgumentNullException(nameof(userIdentityService));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            User user = await _userRepository.Find().Where(u => u.Nickname == context.UserName).FirstOrDefaultAsync();

            if (user == null)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "用户不存在");
                return;
            }

            bool valid = await _userIdentityService.VerifyPasswordAsync(user.Id, context.Password);

            if (!valid)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "请输入正确密码!");
                return;
            }

            await _userRepository.UpdateAsync(user);

            //subjectId 为用户唯一标识 一般为用户id
            //authenticationMethod 描述自定义授权类型的认证方法 
            //authTime 授权时间
            //claims 需要返回的用户身份信息单元
            context.Result = new GrantValidationResult(user.Id.ToString(), OidcConstants.AuthenticationMethods.Password);
        }
    }
}

