using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Shop.Contracts.V1.DTO_requests
{
    public class UpdateCategoryRequestDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
