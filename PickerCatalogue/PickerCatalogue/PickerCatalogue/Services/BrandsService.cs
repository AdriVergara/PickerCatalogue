using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using PickerCatalogue.Interfaces;
using PickerCatalogue.Models;

namespace PickerCatalogue.Services
{
    public class BrandsService : IBrandsService
    {
        public BrandsService()
        {
        }

        public ObservableCollection<Brand> GetBrands()
        {
            var Epiphone = InitEpiphones();
            var Cort = InitCorts();
            var Gibson = InitGibsons();

            var GuitarCollection = new ObservableCollection<Brand>
            {
                Epiphone,
                Cort,
                Gibson
            };

            return GuitarCollection;
        }

        public Brand InitEpiphones()
        {
            var EpiSG = new GuitarModel()
            {
                BrandName = "Epiphone",
                ModelName = "SG G 400",
                ImagesCollection = new ObservableCollection<GuitarImage> { new GuitarImage() { Id = 0, Image = "EpiSG_1.jpg" }, new GuitarImage() { Id = 1, Image = "EpiSG_2.jpg" }, new GuitarImage() { Id = 2, Image = "EpiSG_3.jpg" }, new GuitarImage() { Id = 3, Image = "EpiSG_4.jpg" }, new GuitarImage() { Id = 4, Image = "EpiSG_5.jpg" } },
                Price = 350,
                Stock = 17
            };

            var EpiLP = new GuitarModel()
            {
                BrandName = "Epiphone",
                ModelName = "Les Paul",
                ImagesCollection = new ObservableCollection<GuitarImage> { new GuitarImage() { Id = 0, Image = "EpiLP_1.jpg" }, new GuitarImage() { Id = 1, Image = "EpiLP_2.jpg" }, new GuitarImage() { Id = 2, Image = "EpiLP_3.jpg" }, new GuitarImage() { Id = 3, Image = "EpiLP_4.jpg" }, new GuitarImage() { Id = 4, Image = "EpiLP_5.jpg" } },
                Price = 430,
                Stock = 12
            };

            var Epiphone = new Brand()
            {
                BrandName = "Epiphone",
                Models = new ObservableCollection<GuitarModel> { EpiSG, EpiLP },
                ImagePath = "EpiphoneBrand.jpg"
            };

            return Epiphone;
        }

        public Brand InitCorts()
        {
            var CortG = new GuitarModel()
            {
                BrandName = "Cort",
                ModelName = "G 260",
                ImagesCollection = new ObservableCollection<GuitarImage> { new GuitarImage() { Id = 0, Image = "CortG260_1.jpg" }, new GuitarImage() { Id = 1, Image = "CortG260_2.jpg" }, new GuitarImage() { Id = 2, Image = "CortG260_3.jpg" }, new GuitarImage() { Id = 3, Image = "CortG260_4.jpg" }, new GuitarImage() { Id = 4, Image = "CortG260_5.jpg" } },
                Price = 270,
                Stock = 7
            };

            var CortBO = new GuitarModel()
            {
                BrandName = "Cort",
                ModelName = "BO",
                ImagesCollection = new ObservableCollection<GuitarImage> { /*"Epi.jpeg", "EpiSG2.jpeg"*/ },
                Price = 290,
                Stock = 4
            };

            var Cort = new Brand()
            {
                BrandName = "Cort",
                Models = new ObservableCollection<GuitarModel> { CortG, CortBO },
                ImagePath = "CortBrand.jpg"
            };

            return Cort;
        }

        public Brand InitGibsons()
        {
            var GibsonSG = new GuitarModel()
            {
                BrandName = "Gibson",
                ModelName = "SG",
                ImagesCollection = new ObservableCollection<GuitarImage> { /*"CortG1.jpeg", "CortG2.jpeg", "CortG3.jpeg"*/ },
                Price = 870,
                Stock = 9
            };

            var GibsonLP = new GuitarModel()
            {
                BrandName = "Gibson",
                ModelName = "Les Paul",
                ImagesCollection = new ObservableCollection<GuitarImage> { /*"Epi.jpeg", "EpiSG2.jpeg"*/ },
                Price = 1300,
                Stock = 12
            };

            var Gibson = new Brand()
            {
                BrandName = "Gibson",
                Models = new ObservableCollection<GuitarModel> { GibsonSG, GibsonLP },
                ImagePath = "GibsonBrand.png"
            };

            return Gibson;
        }

    }
}
