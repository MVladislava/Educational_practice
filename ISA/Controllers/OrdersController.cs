using ISA.Models.AddVM;
using ISA.Models.UpdateVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestAspCSDb.Models.Domains;

namespace ISA.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationContext applicationContext;

        public OrdersController(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await applicationContext.Orders.ToListAsync();
            return View(orders);

        }
        [HttpGet]
        public IActionResult AddClient()
        {
            SelectList clients = new SelectList(applicationContext.Clients, "Id", "Name");
            ViewBag.Client = clients;
            return View();
        }
        [HttpGet]
        public IActionResult AddCar()
        {
            SelectList cars = new SelectList(applicationContext.Cars, "Id", "Name");
            ViewBag.Car = cars;
            return View();
        }
        [HttpGet]
        public IActionResult AddStaff()
        {
            SelectList staff = new SelectList(applicationContext.Staffs, "Id", "Name");
            ViewBag.Staff = staff;
            return View();
        }
        [HttpGet]
        public IActionResult AddSpare()
        {
            SelectList spare = new SelectList(applicationContext.Spares, "Id", "Name");
            ViewBag.Spare = spare;
            return View();
        }
        [HttpGet]
        public IActionResult AddService()
        {
            SelectList service = new SelectList(applicationContext.Services, "Id", "Name");
            ViewBag.Service = service;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddOrderViewModel addOrderRequest)
        {
            var order = new Order()
            {
                Id = Guid.NewGuid(),
                Data = addOrderRequest.Data,
                CarsId = addOrderRequest.CarsId,
                ClientsId = addOrderRequest.ClientsId,
                ServicesId = addOrderRequest.ServicesId,
                SparesId = addOrderRequest.SparesId,
                StaffsId = addOrderRequest.StaffsId
            };
            if (ModelState.IsValid)
            {
                await applicationContext.Orders.AddAsync(order);
                await applicationContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(addOrderRequest);
        }
        [HttpGet]
        public async Task<IActionResult> View(Guid Id)
        {
            var order = await applicationContext.Orders.FirstOrDefaultAsync(x => x.Id == Id);
            if (order != null)
            {
                var viewMoodel = new UpdateOrderVM()
                {
                    Id = order.Id,
                    Data = order.Data,
                    CarsId = order.CarsId,
                    ClientsId = order.ClientsId,
                    ServicesId = order.ServicesId,
                    SparesId = order.SparesId,
                    StaffsId = order.StaffsId
                };
                return await Task.Run(() => View("View", viewMoodel));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateOrderVM modelorder)
        {
            var order = await applicationContext.Orders.FindAsync(modelorder.Id);
            if (order != null)
            {
                order.Data = modelorder.Data;
                order.CarsId = order.CarsId;
                order.ClientsId = order.ClientsId;
                order.ServicesId = order.ServicesId;
                order.SparesId = order.SparesId;
                order.StaffsId = order.StaffsId;
                await applicationContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateOrderVM model)
        {
            var order = await applicationContext.Orders.FindAsync(model.Id);
            if (order != null)
            {
                applicationContext.Orders.Remove(order);
                await applicationContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
