using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _16122023_BlogSitesi.Entities
{
    public class Blog:BasedIdWithDate
    {
        [Required]
        public string Baslik { get; set; }

        public string Icerik { get; set; }

        public string AnahtarKelime { get; set; }

        [Required]
        public int KategoriId { get; set; }

        [ForeignKey("KategoriId")]
        public virtual Kategori Kategori { get; set; }
    }
}