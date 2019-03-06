using Refit;
using SweetsDokkana.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SweetsDokkana.Helpers
{
    public interface ISweetDokkanaApi
    {
        //===================================================
        //Product end point
        //===================================================

        [Get("/Bastry")]
        Task<List<Product>> GetBastryProducts();

        [Get("/Cakes")]
        Task<List<Product>> GetCakesProducts();

        [Get("/Western")]
        Task<List<Product>> GetWesternProducts();

        [Get("/Oriental")]
        Task<List<Product>> GetOrientalProducts();
        //===================================================
        //CartOrder end point
        //===================================================

        [Get("/CartOrder")]
        Task<List<CartOrder>> GetCartOrders();

        [Post("/CartOrder")]
        Task<CartOrder> AddCartOrder([Body] CartOrder cartOrder);

        [Delete("/CartOrder/{id}")]
        Task<CartOrder> DeleteCartOrder(string id, [Body] CartOrder cartOrder);

        //===================================================
        //Order end point
        //===================================================

        [Get("/Order")]
        Task<List<Order>> GetOrders();

        [Post("/Order")]
        Task<Order> AddOrder([Body] Order Order);
        
        [Delete("/Order/{id}")]
        Task DeleteOrder(string id, [Body] Order Order);

        //===================================================
        //Customer end point
        //===================================================

        [Get("/Customer")]
        Task<List<Customer>> GetCustomers();

        [Post("/Customer")]
        Task<Customer> AddCustomer([Body] Customer customer);

        [Put("/Customer/{id}")]
        Task<Customer> UpdateCustomers(string id, [Body] Customer customer);

        //===================================================
        //Contact us end point
        //===================================================

        [Post("/ContactUs")]
        Task<Customer> SendMessage([Body] Contact contactMessage);

    }
}
