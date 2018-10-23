using Oblig1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Model.AdminModel;

namespace Oblig1.DAL
{
    /// <summary>
    /// Denne klassen har ansvaret for interaksjon med databasen.
    /// </summary>
	public class LunaContext : DbContext
	{
        /// <summary>
        /// Konstruktøren oppretter et nytt context-instans og linker til
        /// Web.config via connectionstringen "LunaContext".
        /// </summary>
		public LunaContext() : base("name=LunaContext")
		{
			Database.CreateIfNotExists();
		}
        /// <summary>
        /// Disse attributtene oppretter tabellene i databasen.
        /// I tabellene har vi fjernet mange-til-mange relasjoner ved å blant annet
        /// skille ut poststed og postnummer i en egen tabell.
        /// </summary>
		public DbSet<User> Users { get; set; }
		public DbSet<PostalAddress> PostalAddresses { get; set; }
		public DbSet<Movie> Movies { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderLine> OrderLines { get; set; }
        //public DbSet<AdminUser> AdminUsers { get; set; }



	}
}