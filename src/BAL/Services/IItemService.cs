using BAL.DTOs.Item.Request;
using BAL.Dtos.Item.Response;

namespace BAL.Services;

public interface IItemService
{
    Task AddItem(ItemCreateDto testItem);
    
    Task DeleteItem(int id);
    
    Task UpdateItem(int id, ItemUpdateDto testItem);
    
    List<ItemDto> GetAllItems();
    
    ItemDto GetItemById(int id);
}