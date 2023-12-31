﻿using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetListBrand
{
    public class BrandListModel : BasePageableModel
    {
        public IList<BrandListDto> Items { get; set; }
    }
}
