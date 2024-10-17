using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _16122023_BlogSitesi.Entities
{
    public class Kategori:BasedIdWithDate
    {

        [Required]
        public string Ad { get; set; }

        public string Aciklama { get; set; }

        public virtual List<Blog> Bloglar { get; set; }
    }
}