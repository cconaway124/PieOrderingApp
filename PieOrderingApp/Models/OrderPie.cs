namespace PieOrderingApp.Models
{
    public class OrderPie
    {
        // this class represents a one to many relationship with Order
        // i.e one order can have many pies
        // Also captures a "Snapshot" of what the order was, in case the product ID changes, or something like that
        public int OrderPieId { get; set; }
        public int OrderId { get; set; }
        public string PieName { get; set; }
        public string PieDescription { get; set; }
        public string PiePrice { get; set; }
    }
}
