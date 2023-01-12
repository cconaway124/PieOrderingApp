using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using PieOrderingApp.Models;
using PieOrderingApp.ViewModel;
using System.Diagnostics;
using System.Xml.Schema;

namespace PieOrderingApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IPieRepository _pieRepository;
        public CartController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public IActionResult Index([FromForm]OrderViewModel orderVM)
        {
            // this is where I would save the info entered into the DB, but this is just an simple example

            // This converts the "cart" to an actual list of pies. Other ways I could do it is keep track of 
            // the number of pies of a certain ID. This works tp get something off the ground for now
            if (orderVM.SelectedPiesIds != null)
            {
                string[] ids; // catch a string that is not formatted right
                try
                {
                    ids = orderVM.SelectedPiesIds.Split(',');
                } catch (Exception e)
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
                    } catch (Exception e)
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
                orderVM.TotalPrice= total;
            }

            orderVM.Pies = _pieRepository.GetAll();

            return View(orderVM);
        }
    }
}
