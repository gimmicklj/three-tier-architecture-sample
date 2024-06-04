using BLL.Dtos.Item.Request;
using BLL.Dtos.Item.Response;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common.Result;
using BLL.Interface;

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
        return Ok(ApiResult<string>.Ok("add item item success"));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await  itemService.DeleteItem(id);
        logger.LogInformation("delete item item success");
        return Ok(ApiResult<string>.Ok("delete item item success"));
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ItemUpdateDto dto)
    {
        await itemService.UpdateItem(id,dto);
        logger.LogInformation("update test item success");
        return Ok(ApiResult<string>.Ok("update test item success"));

    }
    
    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        var item = itemService.GetItemById(id);
        logger.LogInformation("get item item success");
        return Ok(ApiResult<ItemDto>.Ok(item));

    }
    
    [HttpGet]
    public IActionResult List()
    {
        var items = itemService.GetAllItems();
        logger.LogInformation("list test item success");
        return Ok(ApiResult<List<ItemDto>>.Ok(items));
    }
}