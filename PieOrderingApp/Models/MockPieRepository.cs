namespace PieOrderingApp.Models
{
    public class MockPieRepository : IPieRepository
    {
        public IEnumerable<Pie> GetAll()
        {
            return new List<Pie>
            {
                new Pie { PieId = 1,
                          PieDescription = "A buttery, flaky crust envelopes a delicious cherry filling with a lattice top.",
                          PieName = "Cherry",
                          PiePath = "/Images/cherry_pie.jpg",
                          PiePrice = 15M },
                new Pie { PieId = 2,
                          PieDescription = "A buttery, flaky crust envelopes a delicious blueberry filling with a full top. The blueberries are organic and locally sourced.",
                          PieName = "Blueberry",
                          PiePath = "/Images/blueberry_pie.jpg",
                          PiePrice = 14M },
                new Pie { PieId = 3,
                          PieDescription = "A buttery, flaky crust envelopes a delicious marionberry filling with a lattice top.",
                          PieName = "Marionberry",
                          PiePath = "/Images/marionberry_pie.jpg",
                          PiePrice = 16M },
                new Pie { PieId = 4,
                          PieDescription = "A buttery, flaky crust envelopes a smooth and creamy Chocolate filling with a full top.",
                          PieName = "Chocolate",
                          PiePath = "/Images/chocolate_pie.jpg",
                          PiePrice = 12M }
            };
        }

        public Pie GetPieById(int id)
        {
            return GetAll().FirstOrDefault(p => p.PieId == id) ?? new Pie();
        }
    }
}
