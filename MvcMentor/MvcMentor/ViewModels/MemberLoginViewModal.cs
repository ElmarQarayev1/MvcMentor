using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMentor.ViewModels
{
	public class MemberLoginViewModal
	{
        [MaxLength(25)]
        [MinLength(5)]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(25)]
        [MinLength(8)]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

