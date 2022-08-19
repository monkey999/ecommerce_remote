using DataAccess.Repositories;
using Domain;
using Domain.Interfaces;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerce_WebsiteContext _context;
        public UnitOfWork(ECommerce_WebsiteContext context)
        {
            _context = context;
            CartItems = new CartItemRepository(context);
            Categories = new CategoryRepository(context);
            Orders = new OrderRepository(context);
            Products = new ProductRepository(context);
            PurchasedProducts = new PurchasedProductsRepository(context);
            Users = new UserRepository(context);

        }
        public ICartItemRepository CartItems { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IProductRepository Products { get; private set; }
        public IPurchasedProductsRepository PurchasedProducts { get; private set; }
        public IUserRepository Users { get; private set; }
        public async Task SaveAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}
