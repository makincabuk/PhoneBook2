using PhoneBook2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhoneBook2.Models.Context
{
    public class PhoneContext:DbContext
    {
        public PhoneContext():base("Server=DESKTOP-TI0BQ5A\\WOLVOX8;Database=PhoneBookDB;Trusted_Connection=true")
        {

        }
        public DbSet<Kisi>  Kisiler { get; set; }
        public DbSet<Eposta> Epostalar { get; set; }
        public DbSet<Konum> Konumlar { get; set; }
        public DbSet<Telefon> Telefonlar { get; set; }  
    }
}