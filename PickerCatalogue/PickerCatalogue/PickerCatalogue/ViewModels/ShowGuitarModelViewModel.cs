using CarouselView.FormsPlugin.Abstractions;
using PickerCatalogue.Model;
using PickerCatalogue.Models;
using PickerCatalogue.Views;
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
    public class ShowGuitarModelViewModel : BaseViewModel
    {
        public ObservableCollection<GuitarModel> CarritoModels { get; set; }

        public int _position;
        public int position
        {
            get => _position;
            set
            {
                _position = value;
            }
        }

        public ICommand Swiped { get; set; }
        public ICommand DeleteImage { get; set; }
        public ICommand BuyModel { get; set; }

        public ICommand CarouselImages_Scrolled { get; set; }

        public GuitarModel _modelSelected { get; set; }
        public GuitarModel ModelSelected
        {
            set
            {
                _modelSelected = value;
                OnPropertyChanged("ModelSelected");
            }
            get
            {
                return _modelSelected;
            }
        }

        public CarouselViewControl _myCarousel { get; set; }
        public CarouselViewControl MyCarousel
        {
            set
            {
                _myCarousel = value;
                OnPropertyChanged("MyCarousel");
            }
            get
            {
                return _myCarousel;
            }
        }

        private ObservableCollection<GuitarImage> _ItemsList;

        public ObservableCollection<GuitarImage> ItemsList
        {
            set
            {
                _ItemsList = value;
                OnPropertyChanged("ItemsList");
            }
            get
            {
                return _ItemsList;
            }
        }

        public INavigation _navigationService { get; set; }

        public ShowGuitarModelViewModel(INavigation navigation, GuitarModel selectedModel, ObservableCollection<GuitarModel> carrito)
        {
            _navigationService = navigation;

            CarritoModels = carrito;
            ModelSelected = selectedModel;

            _myCarousel = new CarouselViewControl();
            _ItemsList = ModelSelected.ImagesCollection;
            _myCarousel.ItemsSource = _ItemsList;

            BuyModel = new Command(async () => await ExecuteBuyModel());
        }

        private async Task ExecuteBuyModel()
        {
            CarritoModels.Add(ModelSelected);

            await _navigationService.PushAsync(new PickerView(CarritoModels));
        }
    }
}
