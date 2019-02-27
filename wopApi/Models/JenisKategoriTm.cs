using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace wopApi.Models
{
    public partial class JenisKategoriTm
    {
        [Key]
        public int Id { get; set; }
        public string JenisKategori { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
