using ISA.Models.AddVM;
using ISA.Models.UpdateVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestAspCSDb.Models.Domains;

namespace ISA.Controllers
{
    public class PostsController : Controller
    {
        private readonly ApplicationContext applicationContext;

        public PostsController(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var posts = await applicationContext.Posts.ToListAsync();
            return View(posts);
        }
        [HttpGet]
        public IActionResult Add()
        {
            SelectList posts = new SelectList(applicationContext.Posts, "Id", "Name");
            ViewBag.Posts = posts;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPostViewModel addPostRequest)
        {
            var post = new Post()
            {
                Id = Guid.NewGuid(),
                Name = addPostRequest.Name
            };
            await applicationContext.Posts.AddAsync(post);
            await applicationContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet] //удаление данных о должности
        public async Task<IActionResult> Delete(Guid Id)
        {
            var post = await applicationContext.Posts.FirstOrDefaultAsync(x => x.Id == Id);
            if (post != null)
            {
                applicationContext.Posts.Remove(post);
                await applicationContext.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }
    }
}
