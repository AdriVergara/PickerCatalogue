using PickerCatalogue.Views;
using PickerCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PickerCatalogue.ViewModels
{
    public class PickerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand NextPage { get; set; }
        public ICommand GoToCarrito { get; set; }

        public ObservableCollection<GuitarModel> CarritoModels { get; set; }

        private ObservableCollection<Brand> _brandsToShow { get; set; }
        public ObservableCollection<Brand> BrandsToShow
        {
            get
            {
                return _brandsToShow;
            }
            set
            {
                _brandsToShow = value;
                OnPropertyChanged("BrandsToShow");
            }
        }

        private Brand _brandSelected { get; set; }
        public Brand BrandSelected
        {
            get
            {
                return _brandSelected;
            }
            set
            {
                _brandSelected = value;
                OnPropertyChanged("BrandSelected");

                Visible = "True";
            }
        }

        private GuitarModel _modelSelected { get; set; }
        public GuitarModel ModelSelected
        {
            get
            {
                return _modelSelected;
            }
            set
            {
                _modelSelected = value;
                OnPropertyChanged("ModelSelected");
                //ExecuteCarouselView();
            }
        }

        //private ObservableCollection<CarouselImage> _ItemsList;
        //public ObservableCollection<CarouselImage> ItemsList
        //{
        //    set
        //    {
        //        _ItemsList = value;
        //        OnPropertyChanged("ItemsList");
        //    }
        //    get
        //    {
        //        return _ItemsList;
        //    }
        //}

        //public CarouselViewControl _myCarousel { get; set; }
        //public CarouselViewControl MyCarousel
        //{
        //    set
        //    {
        //        _myCarousel = value;
        //        RaisePropertyChanged("MyCarousel");
        //    }
        //    get
        //    {
        //        return _myCarousel;
        //    }
        //}

        private string _visible { get; set; }
        public string Visible
        {
            get
            {
                return _visible;
            }
            set
            {
                _visible = value;
                OnPropertyChanged("Visible");
            }
        }

        private INavigation Navigation { get; set; }

        public PickerViewModel(INavigation _navigation)
        {
            Navigation = _navigation;

            ModelSelected = new GuitarModel();

            Visible = "False";
            InitializeBrandsAndModels();

            NextPage = new Command(async () => await ExecuteNextPage());
            //GoToCarrito = new Command(async () => await ExecuteGoToCarrito());
        }

        //private async Task ExecuteGoToCarrito()
        //{
        //}

        private async Task ExecuteNextPage()
        {
            await Navigation.PushAsync(new ShowGuitarModelView(ModelSelected, Navigation));
        }

        //public void ExecuteCarouselView()
        //{
        //    _myCarousel = new CarouselViewControl();

        //    var _ItemsList = new ObservableCollection<CarouselImage>
        //    {
        //        new CarouselImage(){ Id=0, Image="ares.png" },
        //        new CarouselImage(){ Id=1, Image="athena.png" },
        //    };

        //    _myCarousel.ItemsSource = _ItemsList;
        //}

        //
        private void InitializeBrandsAndModels()
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

            ///////////////

            BrandsToShow = new ObservableCollection<Brand>
            {
                Epiphone, Cort, Gibson
            };
        }
    }
}
