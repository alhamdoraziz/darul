using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClientApp.Models;
using ClientApp.Helper;
using wopApi.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace ClientApp.Controllers
{
    public class HomeController : Controller
    {
        BarangJasaApi _api = new BarangJasaApi();

        public async Task<IActionResult> Index(string sortOrder)
        {
            //ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "jenis_desc" : "";
            //ViewBag.DateSortParm = sortOrder == "CreateDate_desc" ? "CreateDate_desc" : "";
            List<KategoriBarangJasaTm> Kategori = new List<KategoriBarangJasaTm>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/BarangJasa");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                Kategori = JsonConvert.DeserializeObject<List<KategoriBarangJasaTm>>(result);
            }
            return View(Kategori.OrderByDescending(s => s.DateUpdate));
            
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KategoriBarangJasaTm model)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _api.Initial();
                model.Nikinput = "dummyNIK";
                model.Nikupdate = "dummyNIK";
                var jsonRequest = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync("api/BarangJasa", content);
                TempData["message"] = "success!";
                return RedirectToAction("Index");
            }
            //return RedirectToAction("Index", "Home");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            KategoriBarangJasaTm Kategori = new KategoriBarangJasaTm();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/BarangJasa/"+ id);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                Kategori = JsonConvert.DeserializeObject<KategoriBarangJasaTm>(result);
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View(Kategori);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(KategoriBarangJasaTm model)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _api.Initial();
                model.Nikupdate = "NIKUpdate";
                var jsonRequest = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PutAsync("api/BarangJasa/"+ model.Id, content);
                TempData["message"] = "success!";
                return RedirectToAction("Index");
            }
            //return RedirectToAction("Index", "Home");
            return View(model);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Chstatus(int id)
        {
            //var id = Request.Form["id"];
            HttpClient client = _api.Initial();
            var nikApprover = "test";
            var jsonRequest = "{\"id\":\"" + id + "\", \"status\":\"" + Request.Form["status"] + "\", \"nikapprover\":\""+nikApprover+"\"}";
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
            HttpResponseMessage res = await client.PutAsync("api/BarangJasa/" + id, content);
            TempData["message"] = jsonRequest + "success!";
            return res;
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
