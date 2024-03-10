
using System.ComponentModel.DataAnnotations;

namespace crud.Models;

public class UserModel
{
    [Key]
    public int UserId { get; set; }
    [Required]
    public required string Name { get; set; }

    public string? Email { get; set; }
}
