using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneBook2.Models.Entities
{
    public class Kisi
    {
        public int Id { get; set; }
        public string UUID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Firma { get; set; }
    }
}