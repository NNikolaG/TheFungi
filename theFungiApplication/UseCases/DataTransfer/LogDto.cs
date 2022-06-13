using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace theFungiApplication.UseCases.DataTransfer
{
    public class LogDto
    {
        public string UseCase { get; set; }
        public string Identity { get; set; }
        public DateTime PerformedAt { get; set; }
    }
}
