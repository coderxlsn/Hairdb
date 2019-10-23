using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hairdb.Areas.API.Model
{
    public class RemoveCalendarInputModel
    {
        [Required]
        [StringLength(50)]
        [RegularExpression("[a-zA-Z0-9א-ת -.,=/@_&;]+")]
        public string UserName { get; set; }
        [Required]
        [RegularExpression("[a-zA-Z0-9-]+")]
        public string EventId { get; set; }
    }
}
