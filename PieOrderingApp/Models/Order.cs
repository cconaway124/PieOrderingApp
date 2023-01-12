namespace PieOrderingApp.Models
{
    public class Order
    {
        // Keeps track of what the person is ordering
        
        public int OrderId { get; set; }
        public IEnumerable<OrderPie> OrderPies { get; set; } = new List<OrderPie>();// represents the many pies possible for one order
        public string FName { get; set; } = string.Empty;
        public string LName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime PickupDate { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
