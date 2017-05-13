using OAuth.Repository.Entities;
using System;
using System.Linq;
namespace OAuth.Repository.Repository
{
    public interface IOrderRepository : IDisposable
    {
        int CreateOrder(Order obj);
        int UpdateOrder(Order obj);
        IQueryable<Order> GetAllOrder();
        Order GetOrder(int Id);
        int DeleteOrder(Order obj);
    }
}
