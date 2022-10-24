using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.Services
{
    public interface IPurchasedProductService
    {
        Task<bool> CreatePurchasedProductAsync(PurchasedProduct purchasedProduct);
        Task<IEnumerable<PurchasedProduct>> GetPurchasedProductsAsync();
        Task<PurchasedProduct> GetPurchasedProductByIdAsync(int purchasedProductId);
        Task<bool> UpdatePurchasedProductAsync(PurchasedProduct purchasedProduct);
        Task<bool> DeletePurchasedProductAsync(int purchasedProductId);
    }
}