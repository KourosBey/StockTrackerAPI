namespace Helper.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedTime { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedTime { get; set; }
    }
}