using ISA.Models.AddVM;
using ISA.Models.UpdateVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestAspCSDb.Models.Domains;

namespace ISA.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationContext applicationContext;

        public CarsController(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cars = await applicationContext.Cars.ToListAsync();
            return View(cars);

        }
        [HttpGet]
        public IActionResult Add()
        {
            SelectList clients = new SelectList(applicationContext.Clients, "Id", "Name");
            ViewBag.Client = clients;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCarViewModel addCarRequest)
        {
            var car = new Car()
            {
                Id = Guid.NewGuid(),
                RegNumber = addCarRequest.RegNumber,
                Brand = addCarRequest.Brand,
                Model = addCarRequest.Model,
                ClientId = addCarRequest.ClientId
            };
            if (ModelState.IsValid)
            {
                await applicationContext.Cars.AddAsync(car);
                await applicationContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(addCarRequest);
        }
        [HttpGet]
        public async Task<IActionResult> View(Guid Id)
        {
            var car = await applicationContext.Cars.FirstOrDefaultAsync(x => x.Id == Id);
            if (car != null)
            {
                var viewMoodel = new UpdateCarVM()
                {
                    Id = car.Id,
                    RegNumber = car.RegNumber,
                    Brand = car.Brand,
                    Model = car.Model,
                    ClientId = car.ClientId
                };
                return await Task.Run(() => View("View", viewMoodel));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateCarVM modelcar)
        {
            var car = await applicationContext.Cars.FindAsync(modelcar.Id);
            if (car != null)
            {
                car.RegNumber = modelcar.RegNumber;
                car.Brand = modelcar.Brand;
                car.Model = modelcar.Model;
                await applicationContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateCarVM model)
        {
            var car = await applicationContext.Cars.FindAsync(model.Id);
            if (car != null)
            {
                applicationContext.Cars.Remove(car);
                await applicationContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
