using CarouselView.FormsPlugin.Abstractions;
using PickerCatalogue.Model;
using PickerCatalogue.Models;
using PickerCatalogue.Views;
using Rg.Plugins.Popup.Services;
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
        public ICommand ImageZoomCommand { get; set; }

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

        public string _image { get; set; }
        public string Image
        {
            set
            {
                _image = value;
                OnPropertyChanged("Image");
            }
            get
            {
                return _image;
            }
        }

        public string _stockImage { get; set; }
        public string StockImage
        {
            set
            {
                _stockImage = value;
                OnPropertyChanged("StockImage");
            }
            get
            {
                return _stockImage;
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

            StockImage = checkAvailability();

            _myCarousel = new CarouselViewControl();
            _ItemsList = ModelSelected.ImagesCollection;
            _myCarousel.ItemsSource = _ItemsList;

            BuyModel = new Command(async () => await ExecuteBuyModel());
            ImageZoomCommand = new Command(async (Param) => await ExecuteImageZoomCommand(Param));
        }

        public static async void testt(string param)
        {
            //string image = /*param.ToString();*/ ModelSelected.ImagesCollection[0].Image.ToString();

            await PopupNavigation.Instance.PushAsync(new GuitarImagePopUp(param));
        }

        private async Task ExecuteImageZoomCommand(object param)
        {

            string image = /*param.ToString();*/ ModelSelected.ImagesCollection[0].Image.ToString();

            await PopupNavigation.Instance.PushAsync(new GuitarImagePopUp(image));
        }

        private string checkAvailability()
        {
            int Stock = ModelSelected.Stock;
            string ImageName = "";

            if (Stock >= 10)
            {
                ImageName = "StockGreen.png";
            }
            else if(Stock > 0)
            {
                ImageName = "StockYellow.png";
            }
            else
            {
                ImageName = "StockRed.png";
            }

            return ImageName;
        }

        void OnTapped(object sender, EventArgs e)
        {
            //taps++;
            //var img = (Image)sender;
            //Debug.WriteLine($"tapped: {taps}  {img.Name}");
        }

        private async Task ExecuteBuyModel()
        {
            CarritoModels.Add(ModelSelected);

            await _navigationService.PushAsync(new PickerView(CarritoModels));
        }
    }
}
