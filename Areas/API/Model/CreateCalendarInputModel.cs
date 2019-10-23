using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hairdb.Areas.API.Model
{
    public class CreateCalendarInputModel
    {
        [Required]
        [StringLength(50)]
        [RegularExpression("[a-zA-Z0-9א-ת -.,=/@_&;]+")]
        public string UserName { get; set; }
        [Required]
        [StringLength(12)]
        [RegularExpression("[0-9]{12}")]
        public int StartDateTime { get; set; }
        [Required]
        [StringLength(12)]
        [RegularExpression("[0-9]{12}")]
        public int EndDateTime { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression("[a-zA-Z0-9א-ת -.,=/@_&;]+")]
        public string ClientName { get; set; }
        [Required]
        [StringLength(100)]
        [RegularExpression("[a-zA-Z0-9א-ת -.,=/@_&;]+")]
        public string EventName { get; set; }
        [Required]
        [StringLength(100)]
        [RegularExpression("[a-zA-Z0-9א-ת -.,=/@_&;]+")]
        public string EventDescription { get; set; }
        [Required]
        public int AddbyUserId { get; set;}

    }
}
