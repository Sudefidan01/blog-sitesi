using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _16122023_BlogSitesi.Entities
{
    public class Admin:BasedIdWithDate
    {
        [Required]
        public string Ad { get; set; }

        [Required]
        public string Soyad { get; set; }

        [Required]
        public string KullaniciAdi { get; set; }

        [Required]
        public string Parola { get; set; }
    }
}