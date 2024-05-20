using System.ComponentModel.DataAnnotations;

namespace asp_exam_iliyana.Models
{
    public class Order
    {
        private Guid _id = Guid.NewGuid();
        [Key]
        public Guid Id { get { return _id; } set { _id = value; } }

        private DateTime _date;
        public DateTime Date { get { return _date; } set { _date = value; } }

        private string _customerId;
        [Required]
        public string CustomerId { get { return _customerId; } set { _customerId = value; } }
        public User Customer { get; set; }

        private Guid _cakeId;
        [Required]
        public Guid CakeId { get { return _cakeId; } set { _cakeId = value; } }
        public Cake Cake { get; set; }

        private string? _message;
        [StringLength(30, ErrorMessage = "Max 30 characters")]
        public string? Message { get { return _message; } set { _message = value; } }

        private string _customerAddress;
        public string CustomerAddress { get { return _customerAddress; } set { _customerAddress = value; } }

        private double _shippingFee;
        public double ShippingFee { get; set; }

        private double _totalPrice;
        public double TotalPrice { get; set; }

        public Order(string customerId, Guid cakeId, string message = "")
        {
            Date = DateTime.Now;
            CustomerId = customerId;
            CakeId = cakeId;
            Customer.Id = CustomerId;
            CustomerAddress = Customer.Address;
            ShippingFee = 4.50;
            TotalPrice = ShippingFee + Cake.Price;

            if(message == "")
            {
                Message = "Happy Birthday" + Customer.FirstName;
            } else
            {
                Message = message;
            }
        }
    }
}