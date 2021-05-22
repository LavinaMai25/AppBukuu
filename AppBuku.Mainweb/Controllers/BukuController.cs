using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AppBuku.Models;

namespace AppBuku.Mainweb.Controllers
{
    public class BukuController : Controller
    {
        private string dbname = "belajar.litedb";
        private string dbFilename;
        AppBuku.Models.Data.BukuProcessing bukuProcessing;
        //string pathUtama = System.IO.Directory.GetCurrentDirectory();

        //var file1 = System.IO.Path.Combine(pathUtama, filename);
        //    return Data.MainOperations.ReadPanas(file1);

        public BukuController()
        {
            string pathUtama = System.IO.Directory.GetCurrentDirectory();
            dbFilename = System.IO.Path.Combine(pathUtama, dbname);
            bukuProcessing = new AppBuku.Models.Data.BukuProcessing(dbFilename);
        }

        // GET: BukuController
        public ActionResult Index()
        {
            var bukuSet = bukuProcessing.GetAll();
            if (bukuSet.Count() <= 0) // apabila tidak ada data buku
            {
                foreach (Buku item in Buku.Contoh())
                {
                    bukuProcessing.Insert(item);
                }
                bukuSet = bukuProcessing.GetAll().ToList();
            }

            return View(bukuSet);
        }

        // GET: BukuController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BukuController/Create
        public ActionResult Create()
        {
            Buku buku = new Buku();
            return View(buku);
        }

        // POST: BukuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Buku buku)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string h = bukuProcessing.Insert(buku);
                    if (h.StartsWith("S:"))
                        return RedirectToAction(nameof(Index));
                    else
                        ViewBag.PesanError = h;
                }
                return View(buku);
            }
            catch
            {
                return View(buku);
            }
        }

        // GET: BukuController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BukuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BukuController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BukuController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
