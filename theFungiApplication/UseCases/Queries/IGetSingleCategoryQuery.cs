using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFungiApplication.UseCases.DataTransfer;

namespace theFungiApplication.UseCases.Queries
{
    public interface IGetSingleCategoryQuery : IQuery<int, CategoriesDto>
    {
    }
}
