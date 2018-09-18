using System;
using System.Collections.Generic;

namespace Vuighe.Service.Dtos.Category
{
    public class CategoryGetByIdsDto
    {
        public List<Guid> CategoryIds { get; set; }
    }
}