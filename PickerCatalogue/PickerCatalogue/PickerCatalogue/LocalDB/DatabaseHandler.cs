using PickerCatalogue.Models;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PickerCatalogue.LocalDB
{
    public class DatabaseHandler
    {
        private readonly Task createTables;

        private static string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.db");

        SQLiteConnection _db = new SQLiteConnection(databasePath);

        public DatabaseHandler()
        {
            _db = new SQLiteConnection(databasePath);

            CreateTables();

            if (_db.Query<Brand2>("SELECT * FROM Brands").Count == 0)
            {
                InitiateMockData();
            }
            //_db.DeleteAll<Brand2>();
        }

        public List<Brand2> GetBrands()
        {
            return _db.Query<Brand2>("SELECT * FROM Brands");
        }

        public List<GuitarModel2> GetModels()
        {
            return _db.Query<GuitarModel2>("SELECT * FROM Models");
        }

        private void InitiateMockData()
        {
            AddBrands();
            AddModels();
        }

        private void CreateTables()
        {
            _db.CreateTable<Brand2>();
            _db.CreateTable<GuitarModel2>();
        }

        private void AddBrands()
        {
            var Epiphone = new Brand2()
            {
                Name = "Epiphone",
                Image = "EpiphoneBrand.jpg"
            };

            var Cort = new Brand2()
            {
                Name = "Cort",
                Image = "CortBrand.jpg",
            };

            var Gibson = new Brand2()
            {
                Name = "Gibson",
                Image = "GibsonBrand.png"
            };

            _db.Insert(Epiphone);
            _db.Insert(Cort);
            _db.Insert(Gibson);
        }

        private void AddModels()
        {
            var EpiSG = new GuitarModel2()
            {
                BrandId = 1,
                Name = "SG G 400",
                Rating = 4.3,
                Price = 350,
                Stock = 17,
            };

            var EpiLP = new GuitarModel2()
            {
                BrandId = 1,
                Name = "Les Paul",
                Rating = 4.1,
                Price = 430,
                Stock = 12,
            };

            var CortG = new GuitarModel2()
            {
                BrandId = 2,
                Name = "G 260",
                Rating = 3.2,
                Price = 270,
                Stock = 7,
            };

            var CortBO = new GuitarModel2()
            {
                BrandId = 2,
                Name = "BO",
                Rating = 3.8,
                Price = 290,
                Stock = 4,
            };

            var GibsonSG = new GuitarModel2()
            {
                BrandId = 3,
                Name = "SG",
                Rating = 4.8,
                Price = 2370,
                Stock = 4,
            };

            var GibsonLP = new GuitarModel2()
            {
                BrandId = 3,
                Name = "Les Paul",
                Rating = 4.6,
                Price = 1840,
                Stock = 7,
            };

            _db.Insert(EpiSG);
            _db.Insert(EpiLP);
            _db.Insert(CortG);
            _db.Insert(CortBO);
            _db.Insert(GibsonSG);
            _db.Insert(GibsonLP);
        }

    }
}
