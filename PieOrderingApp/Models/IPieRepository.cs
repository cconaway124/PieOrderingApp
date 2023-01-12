namespace PieOrderingApp.Models
{
    public interface IPieRepository
    {
        public IEnumerable<Pie> GetAll();
        public Pie GetPieById(int id);

    }
}
