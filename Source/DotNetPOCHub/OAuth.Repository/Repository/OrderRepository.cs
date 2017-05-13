
using OAuth.Repository.Context;
using OAuth.Repository.Entities;
using System.Linq;
namespace OAuth.Repository.Repository
{
    public class OrderRepository :IOrderRepository
    {
        private OAuthContext _ctx;
        public OrderRepository()
        {
            _ctx = new OAuthContext();
        }
        public int CreateOrder(Order obj)
        {
            _ctx.Orders.Add(obj);
            return _ctx.SaveChanges();
        }
        public int UpdateOrder(Order obj)
        {
            _ctx.Orders.Add(obj);
            return _ctx.SaveChanges();
        }
        public IQueryable<Order> GetAllOrder()
        {
            return _ctx.Orders;
        }
        public Order GetOrder(int Id)
        {
            return _ctx.Orders.Find(Id);
        }
        public int DeleteOrder(Order obj)
        {
            _ctx.Orders.Remove(obj);
            return _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
