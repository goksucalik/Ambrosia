namespace Ambrosia.Shared.Entities.Abstract
{
    public interface IEntity { }
    public abstract class EntityBase : IEntity
    {
        public EntityBase()
        {
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
            IsActive = true;
            IsDeleted = false;
            CreatedName = "Admin";
            ModifiedName = "Admin";
        }
        public virtual int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime ModifiedDate { get; set; }
        public virtual string CreatedName { get; set; }
        public virtual string ModifiedName { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsDeleted { get; set; }
    }
}
