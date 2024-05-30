using BLL.Dtos.Item.Request;
using BLL.Dtos.Item.Response;
using DAL.Models;

namespace BLL.Mapper;

public static  class ItemMapper
{
    public static ItemDto ToItemDto(this Item item)
    {
        return new ItemDto
        {
            Id = item.Id,
            Name = item.Name,
            Description = item.Description,
            CreatedAt = item.CreatedAt,
            UpdatedAt = item.UpdatedAt
        };
    }
    
    public static IEnumerable<ItemDto> ToItemDtos(this IEnumerable<Item> items)
    {
        return items.Select(item => item.ToItemDto());
    }

    public static Item ToItem(this ItemCreateDto dto)
    {
        return new Item
        {
            Name = dto.Name,
            Description = dto.Description,
        };
    }

    public static Item ToItem(this ItemUpdateDto dto, Item entity)
    {
        entity.Name = dto.Name;
        entity.Description = dto.Description;
        return entity;
    }
}