using System.ComponentModel.DataAnnotations;

namespace DAL.Models;

public class Item: Entity<Guid>
{  
    [Required]
    public string? Name { get; set; }
    
    
    [Required]
    public string? Description { get; set; }
}