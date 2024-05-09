using System.ComponentModel.DataAnnotations;

namespace MvcMentor.Areas.Manage.ViewModels
{
    public class AdminLoginViewModel
    {
        [Required]
        [MinLength(4)]
        [MaxLength(25)]
        public string? UserName { get; set; }
        [Required]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string? Password { get; set; }
    }
}