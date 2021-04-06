using Kholupov.Diploma.TodoApp.Infrastructure;
using Kholupov.Diploma.TodoApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Kholupov.Diploma.TodoApp.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoContext context;

        public ToDoController(ToDoContext context)
        {
            this.context = context;
        }

        // GET /
        public async Task<ActionResult> Index()
        {
            IQueryable<TodoList> items = from i in context.Todos orderby i.Id select i;

            var todoList = await items.ToListAsync();

            return View(todoList);
        }

        //GET /todo / create
        public IActionResult Create() => View();

        //GET / post / create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TodoList item)
        {
            if (ModelState.IsValid)
            {
                context.Add(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The item has been added!";

                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET / todo / edit / 5
        public async Task<ActionResult> Edit(int id)
        {
            var item = await context.Todos.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        //GET / post / edit / 5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TodoList item)
        {
            if (ModelState.IsValid)
            {
                context.Update(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The item has been updated!";

                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET / todo / delete / 5
        public async Task<ActionResult> Delete(int id)
        {
            var item = await context.Todos.FindAsync(id);
            if (item == null)
            {
                TempData["Error"] = "The item does not exist!";
            }
            else
            {
                context.Todos.Remove(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "The item has been deleted!";
            }

            return RedirectToAction("Index");
        }
    }
}
