using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneBook2.Models.Entities
{
    public class Eposta
    {
        public int Id { get; set; }
        public int Uid { get; set; }
        public string UUID { get; set; }
        public string posta { get; set; }

        public string Etiket { get; set; }
    }
}