using PickerCatalogue.Views;
using PickerCatalogue.Models;
using PickerCatalogue.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using PickerCatalogue.Services;

namespace PickerCatalogue.ViewModels
{
    public class PickerViewModel : BaseViewModel
    {
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
            }
        }

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

        private INavigation _navigationService { get; set; }

        private readonly IBrandsService _brandsService;

        public PickerViewModel(INavigation navigation, ObservableCollection<GuitarModel> carrito)
        {
            _navigationService = navigation;

            //initialize carrito only when start the program
            if (carrito == null)
            {
                CarritoModels = new ObservableCollection<GuitarModel>();
            }
            else
            {
                CarritoModels = carrito;
            }

            _brandsService = new BrandsService();

            BrandsToShow = new ObservableCollection<Brand>();
            ModelSelected = new GuitarModel();

            Visible = "False";

            InitializeBrandsAndModels();

            NextPage = new Command(async () => await ExecuteNextPage());
            GoToCarrito = new Command(async () => await ExecuteGoToCarrito());
        }

        private async Task ExecuteGoToCarrito()
        {
            await _navigationService.PushAsync(new CarritoView(CarritoModels));
        }

        private async Task ExecuteNextPage()
        {
            await _navigationService.PushAsync(new ShowGuitarModelView(ModelSelected, CarritoModels));
        }

        private void InitializeBrandsAndModels()
        {
            BrandsToShow = _brandsService.GetBrands();
        }
    }
}
