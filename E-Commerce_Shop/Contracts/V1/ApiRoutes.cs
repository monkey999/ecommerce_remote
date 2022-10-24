namespace E_Commerce_Shop.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;
        public static class Users
        {
            public const string GetAllUsers = Base + "/users";
            public const string GetUserByID = Base + "/users/{userId}";
            public const string AddUser = Base + "/users";
            public const string DeleteUser = Base + "/users/{userId}";
            public const string UpdateUser = Base + "/users/{userId}";
        }

        public static class CartItems
        {
            public const string GetAllCartItems = Base + "/cartitems";
            public const string GetCartItemById = Base + "/cartitems/{cartItemId}";
            public const string AddCartItem = Base + "/cartitems";
            public const string DeleteCartItem = Base + "/cartitems/{cartItemId}";
            public const string UpdateCartItem = Base + "/cartitems/{cartItemId}";
        }
        public static class Categories
        {
            public const string GetAllCategories = Base + "/categories";
            public const string GetCategoryByID = Base + "/categories/{categoryId}";
            public const string AddCategory = Base + "/categories";
            public const string DeleteCategory = Base + "/categories/{categoryId}";
            public const string UpdateCategory = Base + "/categories/{categoryId}";
        }
        public static class Orders
        {
            public const string GetAllOrders = Base + "/orders";
            public const string GetOrderByID = Base + "/orders/{orderId}";
            public const string AddOrder = Base + "/orders";
            public const string DeleteOrder = Base + "/orders/{orderId}";
            public const string UpdateOrder = Base + "/orders/{orderId}";
        }
        public static class Products
        {
            public const string GetAllProducts = Base + "/products";
            public const string GetProductByID = Base + "/products/{productId}";
            public const string AddProduct = Base + "/products";
            public const string DeleteProduct = Base + "/products/{productId}";
            public const string UpdateProduct = Base + "/products/{productId}";
        }
        public static class PurchasedProducts
        {
            public const string GetAllPurchasedProducts = Base + "/purchasedProducts";
            public const string GetPurchasedProductByID = Base + "/purchasedProducts/{purchasedProductId}";
            public const string AddPurchasedProduct = Base + "/purchasedProducts";
            public const string DeletePurchasedProduct = Base + "/purchasedProducts/{purchasedProductId}";
            public const string UpdatePurchasedProduct = Base + "/purchasedProducts/{purchasedProductId}";
        }

    }
}
