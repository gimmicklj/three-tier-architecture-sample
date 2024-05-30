using System.ComponentModel.DataAnnotations;

namespace BAL.DTOs.Item.Request;

public class ItemCreateDto
{
    [Required (ErrorMessage = "名称不能为空")]
    [StringLength(50, ErrorMessage = "字符长度必须在50个字符以内")]
    public string? Name { get; set; }
    
    
    [Required (ErrorMessage = "描述不能为空")]
    [StringLength(200, ErrorMessage = "字符长度必须在200个字符以内")]
    public string? Description { get; set; }
}