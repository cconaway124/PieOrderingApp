using PieOrderingApp.Models;

namespace PieOrderingApp.ViewModel
{
    public class PiesViewModel
    {
        public IEnumerable<Pie> Pies { get; set; }
        public string SelectedPiesIds { get; set; }

    }
}
