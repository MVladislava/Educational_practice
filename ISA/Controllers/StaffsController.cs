using ISA.Models.AddVM;
using ISA.Models.UpdateVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestAspCSDb.Models.Domains;

namespace ISA.Controllers
{
    public class StaffsController : Controller
    {
        private readonly ApplicationContext applicationContext;

        public StaffsController(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var staff = await applicationContext.Staffs.ToListAsync();
            return View(staff);
        }
        [HttpGet]
        public IActionResult Add()
        {
            SelectList posts = new SelectList(applicationContext.Posts, "Id", "Name");
            ViewBag.Post = posts;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStaffViewModel addStaffRequest)
        {
            var staff = new Staff()
            {
                Id = Guid.NewGuid(),
                Surname = addStaffRequest.Surname,
                Name = addStaffRequest.Name,
                Patronymic = addStaffRequest.Patronymic,
                PostsId = addStaffRequest.PostsId
            };
            await applicationContext.Staffs.AddAsync(staff);
            await applicationContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> View(Guid Id)
        {
            var staff = await applicationContext.Staffs.FirstOrDefaultAsync(x => x.Id == Id);
            if (staff != null)
            {
                var viewMoodel = new UpdateStaffVM()
                {
                    Id = staff.Id,
                    Surname = staff.Surname,
                    Name = staff.Name,
                    Patronymic = staff.Patronymic,
                    PostsId = staff.PostsId
                };
                return await Task.Run(() => View("View", viewMoodel));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(UpdateStaffVM model)
        {
            var staff = await applicationContext.Staffs.FindAsync(model.Id);
            if (staff != null)
            {
                staff.Surname = model.Surname;
                staff.Name = model.Name;
                staff.Patronymic = model.Patronymic;
                await applicationContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(UpdateStaffVM model)
        {
            var staff = await applicationContext.Staffs.FindAsync(model.Id);
            if (staff != null)
            {
                applicationContext.Staffs.Remove(staff);
                await applicationContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
