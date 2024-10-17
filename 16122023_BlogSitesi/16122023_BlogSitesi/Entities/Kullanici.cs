using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _16122023_BlogSitesi.Entities
{
    public class Kullanici:BasedIdWithDate
    {
        [Required]
        public string Ad { get; set; }

        [Required]
        public string Soyad { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Parola { get; set; }
    }
}