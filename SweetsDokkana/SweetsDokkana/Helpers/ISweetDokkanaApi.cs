using Refit;
using SweetsDokkana.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SweetsDokkana.Helpers
{
    public interface ISweetDokkanaApi
    {
        [Get("/Product")]
        Task<List<Product>> GetProducts();

        [Post("/CartOrder")]
        Task<CartOrder> AddCartOrder([Body] CartOrder cartOrder);
    }
}
