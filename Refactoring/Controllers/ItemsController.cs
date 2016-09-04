using System.Net;
using System.Web.Mvc;
using Refactoring.Models;
using Refactoring.Data;

namespace Refactoring.Controllers
{
    public class ItemsController : Controller
    {

        private readonly IItemsRepository _repo;

        public ItemsController()
        {
            _repo = new ItemsRepository(new ApplicationDbContext());
        }

        public ItemsController(IItemsRepository repository) // Brukes hvis man skal teste
        {
            _repo = repository;
        }

        // GET: Items
        public ActionResult Index()
        {
            // Vi slipper å bruke datacontexten her
            return View(_repo.GetAll());
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id) // int? betyr Nullable<int>, som pakker inn id. Derfor må vi bruke id.Value
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var item = _repo.GetById(id.Value);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Item item)
        {
            // Refactoring av if:
            if (!ModelState.IsValid) return View(item);

            _repo.Add(item);

            return RedirectToAction("Index");

        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var item = _repo.GetById(id.Value);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Item item)
        {
            if (!ModelState.IsValid) return View(item);

            _repo.Update(item);

            return RedirectToAction("Index");

        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var item = _repo.GetById(id.Value);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
