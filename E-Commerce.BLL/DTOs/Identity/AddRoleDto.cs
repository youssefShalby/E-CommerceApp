namespace E_Commerce.BLL.DTOs;

public class AddRoleDto
{
    [Required(ErrorMessage = "must assign role")]
    [MaxLength(30, ErrorMessage = "the role name cannot be larger than 30 char")]
    [MinLength(2, ErrorMessage = "the role name cannot be less than 2 char")]
    public string Name { get; set; } = string.Empty;
}
