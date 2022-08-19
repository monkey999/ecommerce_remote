using Domain;
using System.Collections.Generic;

namespace Logic.Services
{
    public interface IPurchasedProductService
    {
        void CreatePurchasedProduct(PurchasedProduct purchasedProduct);
        IEnumerable<PurchasedProduct> GetPurchasedProducts();
    }
}