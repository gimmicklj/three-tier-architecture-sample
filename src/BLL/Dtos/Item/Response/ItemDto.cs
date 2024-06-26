﻿namespace BLL.Dtos.Item.Response;

public class ItemDto
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
    
    public  DateTime CreatedAt { get; set; }
    
    public  DateTime ?UpdatedAt { get; set; }
}