using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneBook2.Models.Entities
{
    public class Telefon
    {
        public int Id { get; set; }
        public int Uid { get; set; }
        public string UUID { get; set; }
        public string telefon { get; set; }
        public string Etiket { get; set; }
    }
}