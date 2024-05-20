using asp_exam_iliyana.Models;
using asp_exam_iliyana.Services.Interfaces;

namespace asp_exam_iliyana.Services
{
    public class OrderService : IOrderService
    {
        public bool CancelOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Order GetOrderById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetOrdersCustomer(string Customerid)
        {
            throw new NotImplementedException();
        }

        public bool MakeOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public bool UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
