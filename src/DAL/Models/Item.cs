using System.ComponentModel.DataAnnotations;

namespace DAL.Models;

public class Item: Entity<Guid>
{  
    public string? Name { get; set; }
    
    
    public string? Description { get; set; }
}