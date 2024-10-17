using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _16122023_BlogSitesi.Models
{
    public class LoginViewModel
    {
        [Display (Name ="Kullanıcı Adı")]
        [Required(ErrorMessage ="Kullanıcı Adı boş bırakılamaz")]
        public string KullaniciAdi { get; set; }

        // --------------------------------

        [Display (Name ="Parola")]
        [Required(ErrorMessage ="Parola alanı boş bırakılamaz")]
        [DataType(DataType.Password)]
        public string Parola { get; set; }

        //-----------------------
        [Display (Name ="Parolayı Göster")]
        public bool ParolaAktif { get; set; }
    }
}