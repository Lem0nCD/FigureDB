using FigureDB.Model.Entities.Base;
using FigureDB.Model.Entity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FigureDB.Model.Entities
{
    /// <summary>
    /// 用户身份
    /// </summary>
    public class UserIdentity : BaseEntityGuid
    {
        /// <summary>
        ///认证类型， Password，GitHub、QQ、WeiXin等
        /// </summary>
        public IdentityType IdentityType { get; set; }

        /// <summary>
        /// 认证者，例如 用户名,手机号，邮件等，
        /// </summary>
        [Column(TypeName = "varchar(24)")]
        public string Identifier { get; set; }

        /// <summary>
        ///  凭证，例如 密码,存OpenId、Id，同一IdentityType的OpenId的值是唯一的
        /// </summary>
        [Column(TypeName = "varchar(50)")]
        public string Credential { get; set; }
        /// <summary>
        /// 用户外键
        /// </summary>
        public Guid UserId { get; set; }
        public User User { get; set; }

        public UserIdentity(IdentityType identityType, string credential, Guid userId)
        {
            IdentityType = identityType;
            Credential = credential;
            UserId = userId;
        }

        public UserIdentity(IdentityType identityType, string identifier, string credential, Guid userId)
        {
            IdentityType = identityType;
            Identifier = identifier;
            Credential = credential;
            UserId = userId;
        }
    }
}
