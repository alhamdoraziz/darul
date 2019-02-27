using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace wopApi.Models
{
    public partial class StatusKategoriTm
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
