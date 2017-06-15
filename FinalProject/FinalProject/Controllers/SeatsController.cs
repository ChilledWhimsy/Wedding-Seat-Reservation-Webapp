using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class SeatsController : Controller
    {
        private SeatContext _context;

        public SeatsController(SeatContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var seats = _context.Seats.ToList();

            return View(seats);
        }
        [HttpPost]
        public IActionResult Index(Seat fromView){
            Seat requestedSeat = _context.Seats.Single(b => b.SeatCode == fromView.SeatCode);
            if (requestedSeat != null)
            {
                if (!requestedSeat.Reserved){
                    requestedSeat.OccName = fromView.OccName;
                    requestedSeat.OccAuth = fromView.OccAuth;
                    requestedSeat.Reserved = true;
                    _context.SaveChanges();
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Security()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Security(Seat fromView)
        {
            Seat requestedSeat = _context.Seats.Single(b => b.SeatCode == fromView.SeatCode);
            if (requestedSeat != null)
            {
                return View(requestedSeat);
            }
            else
            {
                return View();
            }
        }
    }
}
