using PhoneBook2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhoneBook2.Models.Context
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext():base("Server=.;Database=Vt_PhoneBook;Irusted_Connection=true")
        {

        }

        public DbSet<Kisi> Kisiler { get; set; }

        public DbSet<Telefon> Telefonlar { get; set; }

        public DbSet<Eposta> Epostalar { get; set; }

        public DbSet<Konum> Konumlar { get; set; }
    }
}