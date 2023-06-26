using ISA.Models.AddVM;
using ISA.Models.UpdateVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestAspCSDb.Models.Domains;

namespace ISA.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ApplicationContext applicationContext;

        public ServicesController(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var services = await applicationContext.Services.ToListAsync();
            return View(services);
        }
        [HttpGet]
        public IActionResult Add()
        {
            SelectList services = new SelectList(applicationContext.Services, "Id", "Name");
            ViewBag.Services = services;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddServiceViewModel addServiceRequest)
        {
            var service = new Service()
            {
                Id = Guid.NewGuid(),
                Name = addServiceRequest.Name
            };
            await applicationContext.Services.AddAsync(service);
            await applicationContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet] //удаление данных об услуге
        public async Task<IActionResult> Delete(Guid Id)
        {
            var service = await applicationContext.Services.FirstOrDefaultAsync(x => x.Id == Id);
            if (service != null)
            {
                applicationContext.Services.Remove(service);
                await applicationContext.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }
    }
}
