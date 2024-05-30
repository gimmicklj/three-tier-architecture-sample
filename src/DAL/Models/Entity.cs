namespace DAL.Models;

public abstract class Entity<TKey> : Entity
{
    public TKey? Id { get; set; }
}
    
public abstract class Entity
{
    public DateTime CreatedAt { get; set; }
    public DateTime ?UpdatedAt { get; set; }
        
    public bool IsDeleted { get; set; }
}