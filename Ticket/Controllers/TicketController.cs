using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace Ticket.Controllers
{
    public class TicketController: Controller 
    {

        private DataContext DbContext;
        public CatalogController(DataContext context) // injecting connection object DB connection
        {
            this.DbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult GetTickets()
        {
            
            var list = DbContext.ServiceTickets.ToList(); // read  ALL in the table (list of Car Objects)
            return Json(list); //send it back as a JSON list
        }

        // public IActionResult GetSedans()
        // {
        //     var list = DbContext.Cars.Where(c => c.Category == "sedan").ToList();
        //     return Json(list);
        // }
        // public IActionResult GetTrucks()
        // {
        //     var list = DbContext.Cars.Where(c => c.Category == "truck").ToList();
        //     return Json(list);
        // }

        [HttpPost]
        public IActionResult CreateServiceTicket([FromBody] ServiceTicket theTicket)
        {
            System.Console.WriteLine("User is creating ticket");

           DbContext.ServiceTickets.Add(theTicket);
           DbContext.SaveChanges();

            return Json(theTicket); // return JSON object
        }

    }
}