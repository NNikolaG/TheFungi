using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theFungiDomain.Entities
{
    public class AuditLog
    {
        public int Id { get; set; }
        public string Command { get; set; }
        public string Identity { get; set; }
        public DateTime PerformedAt { get; set; }
        public string Data { get; set; }
    }
}
