using ISA.Models.AddVM;
using ISA.Models.UpdateVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestAspCSDb.Models.Domains;

namespace ISA.Controllers
{
    public class SparesController : Controller
    {
        private readonly ApplicationContext applicationContext;

        public SparesController(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        [HttpGet] // вывод данных о запчастях в таблицу
        public async Task<IActionResult> Index()
        {
            var spares = await applicationContext.Spares.ToListAsync();
            return View(spares);
        }
        [HttpGet]
        public IActionResult Add()
        {
            SelectList storages = new SelectList(applicationContext.Storages, "Id", "Name");
            ViewBag.Storage = storages;
            return View();
        }

        [HttpPost] // добавление запчасти
        public async Task<IActionResult> Add(AddSpareViewModel addSpareRequest)
        {
            var spare = new Spare()
            {
                Id = Guid.NewGuid(),
                Name = addSpareRequest.Name,
                StoragesId = addSpareRequest.StoragesId
            };
                await applicationContext.Spares.AddAsync(spare);
                await applicationContext.SaveChangesAsync();
                return RedirectToAction("Index");

        }
        [HttpGet] //удаление данных о запчасти
        public async Task<IActionResult> Delete(Guid Id)
        {
            var spare = await applicationContext.Spares.FirstOrDefaultAsync(x => x.Id == Id);
            if (spare != null)
            {

                applicationContext.Spares.Remove(spare);
                await applicationContext.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }

    }
}
