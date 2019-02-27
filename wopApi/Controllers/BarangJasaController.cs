using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wopApi.Models;
using wopApi.DataProvider;

namespace wopApi.Controllers
{
    [Produces("application/json")]
    [Route("api/BarangJasa")]
    public class BarangJasaController : Controller
    {
        private IWOPDataProvider DataProvider;
        public BarangJasaController(IWOPDataProvider DataProvider)
        {
            this.DataProvider = DataProvider;
        }

        [HttpGet]
        public async Task<IEnumerable<KategoriBarangJasaTm>> Get()
        {
            return await this.DataProvider.GetKategoriBarangJasa();
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<KategoriBarangJasaTm> Get(int id)
        {
            return await this.DataProvider.GetKategoriBarangJasa(id);
        }
        
        [HttpPost]
        public async Task Post([FromBody]KategoriBarangJasaTm Kategori)
        {
            await this.DataProvider.AddKategori(Kategori);
        }
        
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]KategoriBarangJasaTm Kategori)
        {
            await this.DataProvider.UpdateKategori(Kategori);
        }
        
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.DataProvider.DeleteKategori(id);
        }
    }
}
