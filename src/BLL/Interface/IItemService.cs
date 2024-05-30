using BLL.Dtos.Item.Request;
using BLL.Dtos.Item.Response;

namespace BLL.Interface;

public interface IItemService
{
    Task AddItem(ItemCreateDto testItem);

    Task DeleteItem(Guid id);

    Task UpdateItem(Guid id, ItemUpdateDto testItem);

    List<ItemDto> GetAllItems();

    ItemDto GetItemById(Guid id);
}