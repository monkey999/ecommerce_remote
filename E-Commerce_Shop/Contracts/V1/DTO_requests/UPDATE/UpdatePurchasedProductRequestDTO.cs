﻿using System;

namespace E_Commerce_Shop.Contracts.V1.DTO_requests.UPDATE
{
    public class UpdatePurchasedProductRequestDTO
    {
        public int CartItemId { get; set; }
        public DateTime DatePurchased { get; set; }
    }
}
