#nullable disable
using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

//Generated from Custom Template.
namespace MVC.Controllers
{
    public class PublishersController : Controller
    {
        private readonly IPublisherService _publisherService;

        public PublishersController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        // GET: Publishers
        public IActionResult Index()
        {
            List<PublisherModel> publisherList = _publisherService.Query().ToList();
            return View(publisherList);
        }

        // GET: Publishers/Details/5
        public IActionResult Details(int id)
        {
            PublisherModel publisher = _publisherService.Query().SingleOrDefault(p => p.Id == id);
            if (publisher == null)
            {
                return View("_Error", "Publisher not found!");
            }
            return View(publisher);
        }

        // GET: Publishers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Publishers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PublisherModel publisher)
        {
            if (ModelState.IsValid)
            {
                var result = _publisherService.Add(publisher);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.Message);
            }
            return View(publisher);
        }

        // GET: Publishers/Edit/5
        public IActionResult Edit(int id)
        {
            PublisherModel publisher = _publisherService.Query().SingleOrDefault(p => p.Id == id);
            if (publisher == null)
            {
                return View("_Error", "Publisher not found!");
            }
            return View(publisher);
        }

        // POST: Publishers/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PublisherModel publisher)
        {
            if (ModelState.IsValid)
            {
                var result = _publisherService.Update(publisher);
                if (result.IsSuccessful)
                {
                    TempData["Message"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.Message);
            }
            return View(publisher);
        }

        // GET: Publishers/Delete/5
        public IActionResult Delete(int id)
        {
            PublisherModel publisher = null; // TODO: Add get item service logic here
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }

        // POST: Publishers/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // TODO: Add delete service logic here
            return RedirectToAction(nameof(Index));
        }
	}
}
