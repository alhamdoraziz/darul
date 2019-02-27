using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace wopApi.Models
{
    public partial class KategoriBarangJasaTm
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Jenis { get; set; }

        [Required]
        [StringLength(30)]
        public string Kategori { get; set; }

        public string Status { get; set; }
        public string Nikinput { get; set; }
        public DateTime? DateInput { get; set; }
        public int? StatusFlow { get; set; }
        public string Nikapprover { get; set; }
        public DateTime? DateApprover { get; set; }
        public string Nikupdate { get; set; }
        public DateTime? DateUpdate { get; set; }
        public bool Empty { get {
                return (Id == 0 && string.IsNullOrWhiteSpace(Jenis) &&
                        string.IsNullOrWhiteSpace(Kategori)
                        );}}
    }
}
