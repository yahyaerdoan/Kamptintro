﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramaworkDemo
{
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocalDB;Database=Northwind;Trusted_Connection=true");
        }
        public DbSet<Product> products { get; set; }

        public DbSet<Personel> Personels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("admin"); // özel şablon olmuş oluyor.
            modelBuilder.Entity<Personel>().ToTable("Employees"); //personeli eployees tablosuna bağlar
            //fluent mapping 1. satırın sonunda devam etmektir.
            modelBuilder.Entity<Personel>().Property(p => p.Id).HasColumnName("EployeeId");
            modelBuilder.Entity<Personel>().Property(p => p.Name).HasColumnName("FirstName");
            modelBuilder.Entity<Personel>().Property(p => p.Surname).HasColumnName("LastName");
        
        }




    }



                              // Override Keywordun kullanımı //

    //public class Yahya
    //{
    //    public override void Metod()
    //    { 
    //        //Herhangibir kodu yeniden düzenleyip yazmak için override etmek gerekir virtual anahtarı ile yaparız.
    //        //metodu başka class metodunda yeniden düzenlemek için kullanırız. Baseclass üzerinde yaparız başka alanda
    //    }
    //}
    //public class Erdoğan : Yahya
    //{
    //    public override void Metod()
    //    {
    //        base.Metod(); //BaseClass burada Yahya içindeki Metodu Erdoğan clasında override edip üzerine yazabiliyoruz.
    //    }
    //}
}
