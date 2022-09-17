using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class PurchasedProductService : IPurchasedProductService
    {
        private readonly IGenericRepository<PurchasedProduct> _purchasedProductRepository;

        public PurchasedProductService(IGenericRepository<PurchasedProduct> purchasedProductRepository)
        {
            _purchasedProductRepository = purchasedProductRepository;
        }

        public async Task<bool> CreatePurchasedProductAsync(PurchasedProduct purchasedProduct)
        {
            await _purchasedProductRepository.AddAsync(purchasedProduct);
            var created = await _purchasedProductRepository.SaveChangesAsyncWithResult();

            return created > 0;
        }

        public async Task<IEnumerable<PurchasedProduct>> GetPurchasedProductsAsync()
        {
            return await _purchasedProductRepository.FindAll()
                            .OrderBy(u => u.Id)
                                .ToListAsync();
        }

        public async Task<PurchasedProduct> GetPurchasedProductByIdAsync(int purchasedProductId)
        {
            return await _purchasedProductRepository.FindByCondition(u => u.Id.Equals(purchasedProductId))
                            .SingleOrDefaultAsync();
        }

        public async Task<bool> UpdatePurchasedProductAsync(PurchasedProduct purchasedProduct)
        {
            _purchasedProductRepository.Update(purchasedProduct);

            var updated = await _purchasedProductRepository.SaveChangesAsyncWithResult();

            return updated > 0;
        }

        public async Task<bool> DeletePurchasedProductAsync(int purchasedProductId)
        {
            var purchasedProduct = await GetPurchasedProductByIdAsync(purchasedProductId);

            if (purchasedProduct == null)
                return false;

            _purchasedProductRepository.RemoveById(purchasedProductId);

            var deleted = await _purchasedProductRepository.SaveChangesAsyncWithResult();

            return deleted > 0;
        }
    }
}
