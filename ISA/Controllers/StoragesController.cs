using ISA.Models.AddVM;
using ISA.Models.UpdateVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestAspCSDb.Models.Domains;

namespace ISA.Controllers
{
    public class StoragesController : Controller
    {
        private readonly ApplicationContext applicationContext;

        public StoragesController(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var storage = await applicationContext.Storages.ToListAsync();
            return View(storage);
        }
        [HttpGet]
        public IActionResult Add()
        {
            SelectList spares = new SelectList(applicationContext.Spares, "Id", "Name");
            ViewBag.Spare = spares;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStorageViewModel addStorageRequest)
        {
            var storage = new Storage()
            {
                Id = Guid.NewGuid(),
                Name = addStorageRequest.Name
            };
            await applicationContext.Storages.AddAsync(storage);
            await applicationContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> View(Guid Id)
        {
            var storage = await applicationContext.Storages.FirstOrDefaultAsync(x => x.Id == Id);
            if (storage != null)
            {
                var viewMoodel = new UpdateStorageVM()
                {
                    Id = storage.Id,
                    Name = storage.Name
                };
                return await Task.Run(() => View("View", viewMoodel));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateStorageVM model)
        {
            var storage = await applicationContext.Storages.FindAsync(model.Id);
            if (storage != null)
            {
                storage.Name = model.Name;
                await applicationContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateStorageVM model)
        {
            var storage = await applicationContext.Storages.FindAsync(model.Id);
            if (storage != null)
            {
                applicationContext.Storages.Remove(storage);
                await applicationContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
