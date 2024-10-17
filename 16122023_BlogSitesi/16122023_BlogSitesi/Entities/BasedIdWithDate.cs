using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _16122023_BlogSitesi.Entities
{
    public class BasedIdWithDate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Boolean Durum { get; set; }

        [Required]
        public DateTime Tarih { get; set; }

        [Required]
        public bool Silindi { get; set; }
    }
}