﻿using SklepInternetowy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace SklepInternetowy.Data_Access_Layer
{
    public class SupplementsInitializer : MigrateDatabaseToLatestVersion<SupplementsContext, Migrations.Configuration>
    {
       
        public static void SeedSupplementsData(SupplementsContext context)
        {
            var categories = new List<Category>
            {
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Odżywki przedtreningowe",
                    IconFileName = "preworkout.png",
                    CategoryDescription = "Pobudzenie i koncentracja przed treningiem"
                },
                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "Odżywki potreningowe",
                    IconFileName = "postworkout.png",
                    CategoryDescription = "Redukcja zmęczenia i szybsza regeneracja po treningu"
                },
                new Category()
                {
                    CategoryId = 3,
                    CategoryName = "Białko",
                    IconFileName = "wpc.png",
                    CategoryDescription = "Pełnowartościowe białko"
                },
                new Category()
                {
                    CategoryId = 4,
                    CategoryName = "Gainer",
                    IconFileName = "gainer.png",
                    CategoryDescription = "Zamiennik pełnowartościowego posiłku"
                },
                new Category()
                {
                    CategoryId = 5,
                    CategoryName = "Prozdrowotne",
                    IconFileName = "healthy.png",
                    CategoryDescription = "Produktu ziołowe pochodzenia naturalnego"
                },
                new Category()
                {
                    CategoryId = 6,
                    CategoryName = "Akcesoria i ubrania",
                    IconFileName = "accesories.png",
                    CategoryDescription = "Akcesoria oraz ubrania"
                },
                new Category()
                {
                    CategoryId = 7,
                    CategoryName = "Witaminy i minerały",
                    IconFileName = "vitamins.png",
                    CategoryDescription = "Najważniejsze elementy zapewniające zdrowie i witalność"
                },
            };

            categories.ForEach(cat => context.Categories.AddOrUpdate(cat));
            context.SaveChanges();

            var supplement = new List<Supplement>()
            {
                new Supplement()
                {
                    SupplementId = 1,
                    Producer = "4Nutrition",
                    Name = "VitaminPack",
                    AddTime = DateTime.Now,
                    Bestseller = true,
                    CategoryId = 7,
                    Price = 20,
                    ImageFileName = "vitamins.png",
                    Description = "Kompleks witamin i minerałów z wysokiej jakości surowców "
                },
                new Supplement()
                {
                    SupplementId = 2,
                    Producer = "4Nutrition",
                    Name = "Białko WPC 80",
                    AddTime = DateTime.Now,
                    Bestseller = true,
                    CategoryId = 3,
                    Price = 40,
                    ImageFileName = "wpc.jpg",
                    Description = "Kompleks białek serwatkowych "
                },

                new Supplement()
                {
                    SupplementId = 3,
                    Producer = "4Nutrition",
                    Name = "Pre Workout Hard Plus",
                    AddTime = DateTime.Now,
                    Bestseller = false,
                    CategoryId = 1,
                    Price = 50,
                    ImageFileName = "preworkout.png",
                    Description = "Mocny stack przedtreningowy zapewniający wzrost siły i koncentracji "
                },

                new Supplement()
                {
                    SupplementId = 4,
                    Producer = "4Nutrition",
                    Name = "MSM Siarka Organiczna",
                    AddTime = DateTime.Now,
                    Bestseller = false,
                    CategoryId = 5,
                    Price = 25,
                    ImageFileName = "healthy2.png",
                    Description = "Organiczna siarka poprawiająca stan stawów, paznokci i włosów"
                },

                new Supplement()
                {
                    SupplementId = 5,
                    Producer = "BodyLogix",
                    Name = "PostWorkout",
                    AddTime = DateTime.Now,
                    Bestseller = true,
                    CategoryId = 2,
                    Price = 60,
                    ImageFileName = "postworkout.png",
                    Description = "Suplement potreningowy zapewniający maksymalnie szybką regenerację"
                },
            };

            supplement.ForEach(s => context.Supplements.AddOrUpdate(s));
            context.SaveChanges();
        }
    }
}