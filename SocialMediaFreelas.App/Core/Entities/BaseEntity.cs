public class BaseEntity : IDefaultEntity
{
    public int Id { get; private set; }
    public bool Actived { get; set; } = true;
    public DateTime CreatedAt { get; private set; } = DateTime.Now;
}