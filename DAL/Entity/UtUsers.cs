using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hairdb.DAL.Entity
{
    public partial class UtUsers
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Userpws { get; set; }
        public string UserGroupId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string ColorId { get; set; }
    }
}
