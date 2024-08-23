using OnionCrafter.Entity.Auditable.Base;
using OnionCrafter.Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace Aura.Domain.Entities.Identity.Base
{
    public abstract class BaseIdentity<Tkey, TkeyCategoryRole, TkeyRefreshToken, TkeyUserRole> : IEntity<Tkey>, IAuditableEntity<Tkey>
                where Tkey : notnull, IEquatable<Tkey>, IComparable<Tkey>
                where TkeyCategoryRole : notnull, IEquatable<TkeyCategoryRole>, IComparable<TkeyCategoryRole>
                where TkeyRefreshToken : notnull, IEquatable<TkeyRefreshToken>, IComparable<TkeyRefreshToken>
                where TkeyUserRole : notnull, IEquatable<TkeyUserRole>, IComparable<TkeyUserRole>

    {
        [Key]
        public Tkey Id { get; set; }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public bool AcceptTerms { get; set; }
        public string VerificationToken { get; set; }
        public DateTime? Verified { get; set; }
        public bool IsVerified => Verified.HasValue || PasswordReset.HasValue;
        public string ResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public DateTime? PasswordReset { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public List<RefreshToken<TkeyRefreshToken, Tkey, TkeyCategoryRole, TkeyCategoryRole>> RefreshTokens { get; set; }
        public DateTime? LastAccessedAt { get; set; }
        public string? LastAccessedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }

        public List<BaseUserRole<TkeyUserRole, Tkey, TkeyCategoryRole, TkeyRefreshToken, Tkey>> UserRoles { get; set; }

        public BaseIdentity()
        {
            UserName = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            PasswordHash = string.Empty;
            AcceptTerms = false;
            VerificationToken = string.Empty;
            ResetToken = string.Empty;
        }

        public abstract BaseIdentity<Tkey, TkeyCategoryRole, TkeyRefreshToken, TkeyUserRole> CreateNewId();

        public bool OwnsToken(string token)
        {
            return RefreshTokens?.Find(x => x.Token == token) != null;
        }

        public abstract void SetId(Tkey key);
    }
}