using OnionCrafter.Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace Aura.Domain.Entities.Identity.Base
{
    public abstract class BaseUserRole<Tkey, TkeyUser, TkeyCategoryRole, TkeyRefreshToken, TkeyIdentity> : BaseEntity<Tkey>
                   where Tkey : notnull, IEquatable<Tkey>, IComparable<Tkey>
                   where TkeyIdentity : notnull, IEquatable<TkeyIdentity>, IComparable<TkeyIdentity>
                   where TkeyUser : notnull, IEquatable<TkeyUser>, IComparable<TkeyUser>
                   where TkeyCategoryRole : notnull, IEquatable<TkeyCategoryRole>, IComparable<TkeyCategoryRole>
                   where TkeyRefreshToken : notnull, IEquatable<TkeyRefreshToken>, IComparable<TkeyRefreshToken>
    {
        [Key]
        public override Tkey Id { get; set; }

        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public BaseCategoryRole<TkeyCategoryRole> CategoryRole { get; set; }
        public bool IsAdministrator { get; set; }
        public List<BaseIdentity<TkeyUser, TkeyCategoryRole, TkeyRefreshToken, TkeyIdentity>> UsersWithRole { get; set; }

        public BaseUserRole()
        {
            Name = string.Empty;
        }
    }
}