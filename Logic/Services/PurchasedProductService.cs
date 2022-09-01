using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


        public void CreatePurchasedProduct(PurchasedProduct purchasedProduct) => _purchasedProductRepository.AddAsync(purchasedProduct);

        public IEnumerable<PurchasedProduct> GetPurchasedProducts() => _purchasedProductRepository.FindAll();
    }
}
