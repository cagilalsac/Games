using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MVC.DbControllers
{
    public class UsersController : Controller
    {
        #region Constructor Dependency Injection
        private readonly GamesDbContext _context;

        public UsersController(GamesDbContext context)
        {
            _context = context;
        }
        #endregion

        // GET: Users
        public IActionResult Index()
        {
            List<User> users = _context.Users.
                Include(u => u.Role).
                OrderByDescending(u => u.IsActive). 
                ThenByDescending(u => u.BirthDate). 
                ThenBy(u => u.UserName). 
                ToList();

            return View(users);
        }

        // GET: Users/Details/5
        public IActionResult Details(int id)
        {
            User user = _context.Users
                .Include(u => u.Role)
                .SingleOrDefault(m => m.Id == id);

            if (user == null)
            {
                return View("_Error", "User couldn't be found!");
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["Roles"] = new SelectList(_context.Roles.OrderBy(r => r.Name).ToList(), "Id", "Name");

            User user = new User()
            {
                IsActive = true,
                BirthDate = new DateTime(2000, 1, 1)
            };
            return View(user);
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid) 
            {
                if (!_context.Users.Any(u => u.UserName.ToUpper() == user.UserName.ToUpper().Trim()))
                {
                    user.UserName = user.UserName.Trim();
                    user.Password = user.Password.Trim();
                    user.Guid = Guid.NewGuid().ToString();

                    _context.Users.Add(user); 
                    _context.SaveChanges(); 

                    TempData["Message"] = "User created successfully.";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "User with the same user name exists!");
            }

            ViewBag.Roles = new SelectList(_context.Roles.OrderBy(r => r.Name).ToList(), "Id", "Name");
            return View(user);
        }

        // GET: Users/Edit/5
        public IActionResult Edit(int id)
        {
            User user = _context.Users.Find(id);

            if (user == null)
            {
                return View("_Error", "User couldn't be found!");
            }

            ViewData["Roles"] = new SelectList(_context.Roles.OrderBy(r => r.Name).ToList(), "Id", "Name");
            return View(user);
        }

        // POST: Users/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid) 
            {
                if (!_context.Users.Any(u => u.UserName.ToUpper() == user.UserName.ToUpper().Trim() && u.Id != user.Id))
                {
                    user.UserName = user.UserName.Trim();
                    user.Password = user.Password.Trim();

                    _context.Users.Update(user); 
                    _context.SaveChanges(); 
                    
                    TempData["Message"] = "User updated successfully.";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "User with the same user name exists!");
            }
            
            ViewBag.Roles = new SelectList(_context.Roles.OrderBy(r => r.Name).ToList(), "Id", "Name");
            return View(user);
        }

        // GET: Users/Delete/5
        public IActionResult Delete(int id)
        {
            User user = _context.Users
                .Include(u => u.Role)
                .SingleOrDefault(m => m.Id == id);

            if (user == null)
            {
                return View("_Error", "User couldn't be found!");
            }

            return View(user);
        }
     
        // POST: Users/Delete
        [HttpPost, ActionName("Delete")] 
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            User user = _context.Users.Find(id); 

            _context.Users.Remove(user); 
            _context.SaveChanges(); 

            TempData["Message"] = "User deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}
