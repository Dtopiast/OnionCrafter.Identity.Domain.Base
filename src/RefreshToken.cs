using OnionCrafter.Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace Aura.Domain.Entities.Identity.Base
{
    public class RefreshToken<Tkey, TkeyIdentity, TkeyCategoryRole, TkeyRefreshToken> : BaseEntity<Tkey>
            where Tkey : notnull, IEquatable<Tkey>, IComparable<Tkey>
            where TkeyIdentity : notnull, IEquatable<TkeyIdentity>, IComparable<TkeyIdentity>
            where TkeyCategoryRole : notnull, IEquatable<TkeyCategoryRole>, IComparable<TkeyCategoryRole>
            where TkeyRefreshToken : notnull, IEquatable<TkeyRefreshToken>, IComparable<TkeyRefreshToken>
    {
        [Key]
        public override Tkey Id { get; set; }

        public BaseIdentity<TkeyIdentity, TkeyCategoryRole, TkeyRefreshToken, TkeyIdentity> User { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string RevokedByIp { get; set; }
        public string ReplacedByToken { get; set; }
        public string ReasonRevoked { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public bool IsRevoked => Revoked != null;
        public bool IsActive => Revoked == null && !IsExpired;
    }
}