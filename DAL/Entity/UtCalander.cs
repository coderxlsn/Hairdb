using System;
using System.Collections.Generic;

namespace Hairdb.DAL.Entity
{
    public partial class UtCalander
    {
        public string EventId { get; set; }
        public int? UserId { get; set; }
        public DateTime? StartDtime { get; set; }
        public DateTime? EndDtime { get; set; }
        public string ClientName { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public int? IsLocked { get; set; }
        public int? AddbyUserId { get; set; }
        public DateTime? CreatedDtime { get; set; }
        public int? IsSms { get; set; }
    }
}
