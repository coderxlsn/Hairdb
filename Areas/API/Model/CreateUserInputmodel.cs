using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hairdb.Areas.API.Model
{

    /// <summary>
    /// Create User
    /// </summary>
    public class CreateUserInputModel
    {
        [Required]
        [StringLength(50)]
        [RegularExpression("[a-zA-Z0-9]+")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression("[a-zA-Z0-9א-ת!@#$%^&*()+-.,=/@_]+")]
        public string UserPassword { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression("[a-zA-Z0-9א-ת]+")]
        public string GroupId { get; set; }
        
        [Required]
        [StringLength(100)]
        [RegularExpression("[a-zA-Z0-9א-ת -.,=/@_&;]+")]
        public string CompanyName { get; set; }
        
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [StringLength(50)]
        [RegularExpression("[a-zA-Z0-9א-ת -.,=/@_&;]+")]
        public string FullName { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression("[a-zA-Z0-9א-ת]+")]
        public string ColorId { get; set; }
    }
}
