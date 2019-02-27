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
using ClientApp.Models;

namespace ClientApp.Controllers
{
    public class TablesController : Controller
    {
        BarangJasaApi _api = new BarangJasaApi();
        [HttpGet]
        public async Task<JsonResult> Kategoridatalist()
        {   
            List<KategoriBarangJasaTm> Kategori = new List<KategoriBarangJasaTm>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/BarangJasa");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                Kategori = JsonConvert.DeserializeObject<List<KategoriBarangJasaTm>>(result);
            }
           List<string[]> datalist = new List<string[]>();
            var no = 0;
            foreach(var item in Kategori)
            {
                no += 1;
                string[] data = {};
                data[0] = no.ToString();
                data[1] = "asdw";
                datalist.Add(data); 
            }
            //$no++;
            //$row = array();
            //$row[]=$no;
            //$row[]=$key['username'];

            return Json(new { aaData=datalist, sEcho = 0,iDisplayTotalRecord=Kategori.Count,iTotalRecords=Kategori.Count });
        }
    }
}