using BookStore.Core.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Contracts
{
    public interface IOrderService
    {
        Task Create(int bookId,string userId);
        Task<IEnumerable<OrderServiceModel>> GetOrders();
    }
}
