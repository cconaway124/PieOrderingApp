namespace PieOrderingApp.Models
{
    public class Pie
    {
        public int PieId { get; set; }
        public string PieDescription { get; set; } = string.Empty;
        public string PieName { get; set; } = string.Empty;
        public string PiePath { get; set; } = string.Empty;
        public decimal PiePrice { get; set; }

    }
}
