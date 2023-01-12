using Microsoft.AspNetCore.Mvc;
using PieOrderingApp.Models;
using PieOrderingApp.ViewModel;

namespace PieOrderingApp.Controllers
{
    public class ConfirmationController : Controller
    {
        private readonly IPieRepository _pieRepository;
        public ConfirmationController(IPieRepository pieRepository) 
        {
            _pieRepository = pieRepository;
        }

        public IActionResult Index([FromForm]OrderViewModel orderVM) 
        {
            // here is where I would commit some more stuff to the database (i.e. approval code, etc.)
            if (orderVM.SelectedPiesIds != null)
            {
                string[] ids; // catch a string that is not formatted right
                try
                {
                    ids = orderVM.SelectedPiesIds.Split(',');
                }
                catch (Exception e)
                {
                    return StatusCode(500);
                }

                decimal total = 0M;
                Dictionary<int, int> pies = new Dictionary<int, int>(); // key int represents PieID
                foreach (string stringId in ids) // convert each string to an int and add to list
                {
                    int id;
                    try
                    {
                        id = int.Parse(stringId);
                    }
                    catch (Exception e)
                    {
                        return StatusCode(500);
                    }
                    Pie currPie = _pieRepository.GetPieById(id);

                    if (pies.TryGetValue(currPie.PieId, out int numOfPies))
                        pies[currPie.PieId] = numOfPies + 1;
                    else
                        pies[currPie.PieId] = 1;
                    total += currPie.PiePrice;
                }
                orderVM.PieCounts = pies; // set list for the orderVM
                orderVM.TotalPrice = total;
            }

            orderVM.Pies = _pieRepository.GetAll();
            return View(orderVM); 
        }
    }
}
