using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Api.Domain.Filter
{
    public abstract class BaseFilter
    {
        public int Page { get; set; }

        public int PageSize { get; set; } = 10;
    }
}
