using BAL.DTOs.Item.Request;
using BAL.Dtos.Item.Response;
using BAL.Mapper;
using DAL.Models;
using DAL.UnitOfWork;

namespace BAL.Services;

public class ItemService(IUnitOfWork unitOfWork) : IItemService
{
    public async Task AddItem(ItemCreateDto dto)
    {
        var repo = unitOfWork.GetRepository<Item,int>();
        var entity = dto.ToItem();
        repo.Add(entity);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteItem(int id)
    {
        var repo = unitOfWork.GetRepository<Item,int>();
        var entity = repo.GetById(id);
        repo.Delete(entity);
        await unitOfWork.SaveChangesAsync();
    }

    public async Task UpdateItem(int id, ItemUpdateDto dto)
    {
        var repo = unitOfWork.GetRepository<Item, int>();
        var entity = repo.GetById(id);
        entity.Name = dto.Name;
        entity.Description = dto.Description;
        repo.Update(entity);
        await unitOfWork.SaveChangesAsync();
    }
    
    public List<ItemDto>  GetAllItems()
    {
        var repo = unitOfWork.GetRepository<Item, int>();
        var entities = repo.GetAll();
        var dtos = entities.ToItemDtos().ToList();
        return dtos;
    }

    public ItemDto GetItemById(int id)
    {
        var repo = unitOfWork.GetRepository<Item, int>();
        var entity = repo.GetById(id);
        var dto = entity.ToItemDto();
        return dto;
    }
}