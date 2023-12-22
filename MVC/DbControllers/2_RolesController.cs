using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MVC.DbControllers
{
    public class RolesController : Controller
    {
        private readonly GamesDbContext _context;

        public RolesController(GamesDbContext context)
        {
            _context = context;
        }

        // GET: Roles
        public IActionResult Index()
        {
            return View(_context.Roles.Include(r => r.Users).OrderBy(r => r.Name).ToList());
        }

        // GET: Roles/Details/5
        public IActionResult Details(int id)
        {
            var role = _context.Roles
                .Include(r => r.Users)
                .SingleOrDefault(m => m.Id == id);

            if (role is null)
            {
                return View("_Error", "Role couldn't be found!");
            }

            return View(role);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Role role)
        {
            if (ModelState.IsValid)
            {
                if (!_context.Roles.Any(r => r.Name.ToUpper() == role.Name.ToUpper().Trim()))
                {
                    _context.Roles.Add(role);
                    _context.SaveChanges();

                    TempData["Message"] = "Role created successfully.";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Role with the same name exists!");
            }
            return View(role);
        }

        // GET: Roles/Edit/5
        public IActionResult Edit(int id)
        {
            var role = _context.Roles.Find(id);

            if (role is null)
            {
                return View("_Error", "Role couldn't be found!");
            }

            return View(role);
        }

        // POST: Roles/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Role role)
        {
            if (ModelState.IsValid)
            {
                if (!_context.Roles.Any(r => r.Name.ToUpper() == role.Name.ToUpper().Trim() && r.Id != role.Id))
                {
                    _context.Roles.Update(role);
                    _context.SaveChanges();

                    TempData["Message"] = "Role updated successfully.";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Role with the same name exists!");
            }
            return View(role);
        }

        // GET: Roles/Delete/5
        public IActionResult Delete(int id)
        {
            var role = _context.Roles
                .Include(r => r.Users)
                .SingleOrDefault(m => m.Id == id);

            if (role is null)
            {
                return View("_Error", "Role couldn't be found!");
            }

            return View(role);
        }

        // POST: Roles/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var role = _context.Roles
                .Include(r => r.Users)
                .SingleOrDefault(r => r.Id == id);

            if (role.Users.Any())
            {
                TempData["Message"] = "Role can't be deleted because it has relational users!";
            }
            else
            {
                _context.Roles.Remove(role);
                _context.SaveChanges();

                TempData["Message"] = "Role deleted successfully.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
