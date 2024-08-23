using OnionCrafter.Entity.Base;
using OnionCrafter.Util.Object.Auditable;
using System.ComponentModel.DataAnnotations;

namespace Aura.Domain.Entities.Identity.Base
{
    public abstract class BaseCategoryRole<Tkey> : BaseEntity<Tkey>, IAuditable
           where Tkey : notnull, IEquatable<Tkey>, IComparable<Tkey>
    {
        [Key]
        public override Tkey Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? LastAccessedAt { get; set; }

        public string? LastAccessedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? CreatedBy { get; set; }
    }
}