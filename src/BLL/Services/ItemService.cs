using BLL.Dtos.Item.Request;
using BLL.Dtos.Item.Response;
using BLL.Interface;
using BLL.Mapper;
using DAL.Interface;
using DAL.Models;

namespace BLL.Services;

public class ItemService(IUnitOfWork unitOfWork) : IItemService
{
    public async Task AddItem(ItemCreateDto dto)
    {
        var repo = unitOfWork.GetRepository<Item,Guid>();
        var entity = dto.ToItem();
        repo.Add(entity);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteItem(Guid id)
    {
        var repo = unitOfWork.GetRepository<Item,Guid>();
        var entity = repo.GetById(id);
        repo.Delete(entity);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateItem(Guid id, ItemUpdateDto dto)
    {
        var repo = unitOfWork.GetRepository<Item, Guid>();
        var entity = dto.ToItem(repo.GetById(id));
        repo.Update(entity);
        await unitOfWork.SaveChangesAsync();
    }
    
    public List<ItemDto>  GetAllItems()
    {
        var repo = unitOfWork.GetRepository<Item, Guid>();
        var entities = repo.GetAll();
        var dtos = entities.ToItemDtos().ToList();
        return dtos;
    }

    public ItemDto GetItemById(Guid id)
    {
        var repo = unitOfWork.GetRepository<Item, Guid>();
        var entity = repo.GetById(id);
        var dto = entity.ToItemDto();
        return dto;
    }
}