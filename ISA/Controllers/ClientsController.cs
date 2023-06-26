using ISA.Models.AddVM;
using ISA.Models.UpdateVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAspCSDb.Models.Domains;

namespace ISA.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ApplicationContext applicationContext;

        public ClientsController(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        [HttpGet] //вывод данных о клиенте в таблицу
        public async Task<IActionResult> Index()
        {
            var clients = await applicationContext.Clients.ToListAsync();
            return View(clients);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost] // добавление данных о клиенте в бд
        public async Task<IActionResult> Add(AddClientViewModel addClientRequest)
        {
            var client = new Client()
            {
                Id = Guid.NewGuid(),
                Surname = addClientRequest.Surname,
                Name = addClientRequest.Name,
                Patronymic = addClientRequest.Patronymic,
                DateOfB = addClientRequest.DateOfB
            };
            if (ModelState.IsValid)
            {
                await applicationContext.Clients.AddAsync(client);
                await applicationContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(addClientRequest);
        }
        [HttpGet] //посик клиента по его ID
        public async Task<IActionResult> View(Guid Id)
        {
            var client = await applicationContext.Clients.FirstOrDefaultAsync(x => x.Id == Id);
            if (client != null)
            {
                var viewMoodel = new UpdateClientVM()
                {
                    Id = client.Id,
                    Surname = client.Surname,
                    Name = client.Name,
                    Patronymic = client.Patronymic,
                    DateOfB = client.DateOfB
                };
                return await Task.Run(() => View("View", viewMoodel));
            }
            return RedirectToAction("Index");
        }
        [HttpPost] //изменение данных о клиенте и сохранение изменений
        public async Task<IActionResult> View(UpdateClientVM model)
        {
            var client = await applicationContext.Clients.FindAsync(model.Id);
            if (client != null)
            {
                client.Surname = model.Surname;
                client.Name = model.Name;
                client.Patronymic = model.Patronymic;
                client.DateOfB = model.DateOfB;
                
            }
            if (ModelState.IsValid)
            {
                await applicationContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(client);
        }
        [HttpPost] //удаление записи из базы данных
        public async Task<IActionResult> Delete(UpdateClientVM model)
        {
            var client = await applicationContext.Clients.FindAsync(model.Id);
            if (client != null)
            {
                applicationContext.Clients.Remove(client);
                await applicationContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
