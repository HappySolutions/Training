using Refit;
using SweetsDokkana.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SweetsDokkana.Helpers
{
    public interface ISweetDokkanaApi
    {
        [Get("/Product")]
        Task<List<Product>> GetProducts();

        [Get("/CartOrder")]
        Task<List<CartOrder>> GetCartOrders();

        [Post("/CartOrder")]
        Task<CartOrder> AddCartOrder([Body] CartOrder cartOrder);

        [Post("/Order")]
        Task<Order> AddOrder([Body] Order Order);

        [Get("/Order")]
        Task<List<Order>> GetOrders();

    }
}
