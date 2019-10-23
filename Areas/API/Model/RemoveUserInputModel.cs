using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hairdb.Areas.API.Model
{
    public class RemoveUserInputModel
    {
        [Required]
        [StringLength(50)]
        [RegularExpression("[a-zA-Z0-9א-ת]+")]
        public string GroupId { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression("[a-zA-Z0-9]+")]
        public string UserName { get; set; }

    }
}
