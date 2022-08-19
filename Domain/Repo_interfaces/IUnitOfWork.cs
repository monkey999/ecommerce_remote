using Domain.Interfaces;
using System.Threading.Tasks;

namespace Domain
{
    public interface IUnitOfWork
    {
        ICartItemRepository CartItems { get; }
        ICategoryRepository Categories { get; }
        IOrderRepository Orders { get; }
        IProductRepository Products { get; }
        IPurchasedProductsRepository PurchasedProducts { get; }
        IUserRepository Users { get; }

        void Dispose();
        Task SaveAsync();
    }
}