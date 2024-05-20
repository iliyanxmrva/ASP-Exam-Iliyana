using asp_exam_iliyana.Models;

namespace asp_exam_iliyana.Services.Interfaces
{
    public interface IOrderService
    {
        public bool MakeOrder(Order order);
        public bool UpdateOrder(Order order);
        public bool CancelOrder(Order order);

        public Order GetOrderById(string id);
        public IEnumerable<Order> GetAllOrders();

        public IEnumerable<Order> GetOrdersCustomer(string Customerid);
    }
}
