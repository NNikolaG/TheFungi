using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.DataTransfer;

namespace theFungiApplication.UseCases.DataTransfer
{
    public class CreateCollectionItemWithImage : CollectionItemCreateDto
    {
        public IFormFile ImageFile { get; set; }
    }
}
