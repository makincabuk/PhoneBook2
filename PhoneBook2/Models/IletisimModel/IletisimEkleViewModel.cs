using PhoneBook2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneBook2.Models.IletisimModel
{
    public class IletisimEkleViewModel
    {
        public Kisi Kisi { get; set; }
        public List<Telefon> TelefonL { get; set; }
        public Telefon  Telefon { get; set; }
        public List<Eposta> EpostaL { get; set; }
        public Eposta Eposta { get; set; }
        public List<Konum> KonumL { get; set; }
        public Konum Konum { get; set; }
    }
}