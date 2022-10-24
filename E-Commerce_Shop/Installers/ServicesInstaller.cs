using DataAccess;
using DataAccess.Repositories;
using Domain;
using Domain.Interfaces;
using Logic.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce_Shop.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddTransient<ECommerce_WebsiteContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<ICartItemRepository, CartItemRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IPurchasedProductsRepository, PurchasedProductsRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<ICartItemService, CartItemService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IPurchasedProductService, PurchasedProductService>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
