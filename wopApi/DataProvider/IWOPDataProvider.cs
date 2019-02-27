using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wopApi.Models;

namespace wopApi.DataProvider
{
    public interface IWOPDataProvider
    {
        Task<IEnumerable<KategoriBarangJasaTm>> GetKategoriBarangJasa();
        Task<IEnumerable<JenisKategoriTm>> GetJenisKategori();
        Task<IEnumerable<StatusKategoriTm>> GetStatusKategori();

        Task<KategoriBarangJasaTm> GetKategoriBarangJasa(int id);

        Task AddKategori(KategoriBarangJasaTm Kategori);

        Task UpdateKategori(KategoriBarangJasaTm Kategori);

        Task DeleteKategori(int id);

        Task GetList();
    }
}
