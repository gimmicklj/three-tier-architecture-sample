using BAL.DTOs.Item.Request;
using BAL.Dtos.Item.Response;
using BAL.Services;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common.Result;

namespace WebApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ItemController(ILogger<ItemController> logger, IItemService itemService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] ItemCreateDto dto)
    {
        await itemService.AddItem(dto);
        logger.LogInformation("add item item success");
        return Ok(Result<string>.Ok("add item item success"));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await  itemService.DeleteItem(id);
        logger.LogInformation("delete item item success");
        return Ok(Result<string>.Ok("delete item item success"));
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update( int id, [FromBody] ItemUpdateDto dto)
    {
        await itemService.UpdateItem(id,dto);
        logger.LogInformation("update test item success");
        return Ok(Result<string>.Ok("update test item success"));

    }
    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var item = itemService.GetItemById(id);
        logger.LogInformation("get item item success");
        return Ok(Result<ItemDto>.Ok(item));

    }
    
    [HttpGet]
    public IActionResult List()
    {
        var items = itemService.GetAllItems();
        logger.LogInformation("list test item success");
        return Ok(Result<List<ItemDto>>.Ok(items));
    }
}