using PieOrderingApp.Models;

namespace PieOrderingApp.ViewModel
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public IEnumerable<Pie> Pies { get; set; }
        public string SelectedPiesIds { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime PickupDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Dictionary<int, int> PieCounts { get; set; }
        public decimal TotalPrice { get; set; }
        public string MinOrderableDate { get; set; }
        public string CCName { get; set; }
        public string CCNumber { get; set; }
        public string CVV { get; set; }
        public int ZipCode { get; set; }
    }
}
