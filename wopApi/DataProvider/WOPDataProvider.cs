using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using wopApi.Models;

namespace wopApi.DataProvider
{
    public class WOPDataProvider : IWOPDataProvider
    {
        private readonly string connectionString = "Server=.\\SQLEXPRESS;Database=wop;Trusted_Connection=True;";

        private SqlConnection sqlConnection;

        public async Task AddKategori(KategoriBarangJasaTm Kategori)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Jenis", Kategori.Jenis);
                dynamicParameters.Add("@Kategori", Kategori.Kategori);
                dynamicParameters.Add("@Status", Kategori.Status);
                dynamicParameters.Add("@Nikinput", Kategori.Nikinput);
                dynamicParameters.Add("@StatusFlow", Kategori.StatusFlow);
                dynamicParameters.Add("@NIKUpdate", Kategori.Nikupdate);
                dynamicParameters.Add("@OperationType", 'C');
                await sqlConnection.ExecuteAsync(
                    "spInsertKategoriBarangJasa_TT",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateKategori(KategoriBarangJasaTm Kategori)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id", Kategori.Id);
                dynamicParameters.Add("@Jenis", Kategori.Jenis);
                dynamicParameters.Add("@Kategori", Kategori.Kategori);
                dynamicParameters.Add("@Status", Kategori.Status);
                dynamicParameters.Add("@StatusFlow", Kategori.StatusFlow);
                dynamicParameters.Add("@NIKUpdate", Kategori.Nikupdate);
                dynamicParameters.Add("@NIKApprover", Kategori.Nikapprover);
                dynamicParameters.Add("@OperationType", 'U');
                await sqlConnection.ExecuteAsync(
                    "spUpdateKategoriBarangJasa_TT",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteKategori(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@id", id);
                await sqlConnection.ExecuteAsync(
                    "spDeleteKategoriBarangJasa",
                    dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public Task<IEnumerable<JenisKategoriTm>> GetJenisKategori()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StatusKategoriTm>> GetStatusKategori()
        {
            throw new NotImplementedException();
        }

        public async Task<KategoriBarangJasaTm> GetKategoriBarangJasa(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@id", id);
                return await sqlConnection.QueryFirstOrDefaultAsync<KategoriBarangJasaTm>(
                    sql:"spGetKategoriBarangJasa_TT",
                    param:dynamicParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<KategoriBarangJasaTm>> GetKategoriBarangJasa()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                return await sqlConnection.QueryAsync<KategoriBarangJasaTm>(
                    "spGetKategoriBarangJasa_TT",  
                    null,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task GetList()
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                await sqlConnection.OpenAsync();
                //return await sqlConnection.QueryAsync<KategoriBarangJasaTm>(
                //  query,
                //null,
                //commandType: CommandType.Text);
            }
        }
    }
}