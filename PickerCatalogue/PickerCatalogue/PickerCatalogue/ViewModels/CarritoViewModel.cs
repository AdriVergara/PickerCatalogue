using PickerCatalogue.Models;
using PickerCatalogue.Views;
using Plugin.Notifications;
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
    public class CarritoViewModel : BaseViewModel
    {
        public INavigation _navigationService { get; set; }

        private ObservableCollection<GuitarModel> _carritoModels { get; set; }
        public ObservableCollection<GuitarModel> CarritoModels
        { 
            set
            {
                _carritoModels = value;
                OnPropertyChanged("CarritoModels");
            }
            get
            {
                return _carritoModels;
            }
        }

        private GuitarModel _selectedItem { get; set; }
        public GuitarModel SelectedItem
        {
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
            get
            {
                return _selectedItem;
            }
        }

        private double _totalCarrito { get; set; }
        public double TotalCarrito
        {
            set
            {
                _totalCarrito = value;
                OnPropertyChanged("TotalCarrito");
            }
            get
            {
                return _totalCarrito;
            }
        }

        //Workaround to command from object inside a listview
        public ICommand GoToGuitarModelCommand
        {
            get
            {
                return new Command((e) =>
                {
                    var item = (e as GuitarModel);

                    _navigationService.PushAsync(new ShowGuitarModelView(item, CarritoModels));
                });
            }
        }

        //Workaround to command from object inside a listview
        public ICommand DeleteCartProductCommand
        {
            get
            {
                return new Command((e) =>
                {
                    var item = (e as GuitarModel);

                    CarritoModels.Remove(item);
                    TotalCarrito = CalculateTotal();
                });
            }
        }

        public CarritoViewModel(INavigation navigation, ObservableCollection<GuitarModel> carrito)
        {
            _navigationService = navigation;

            CarritoModels = carrito;

            TotalCarrito = CalculateTotal();

            //DeleteCartProductCommand = new Command(async () => await ExecuteDeleteCartProductCommand());
        }

        //private async Task ExecuteDeleteCartProductCommand()
        //{
        //    //await CrossNotifications.Current.Send("Deleting item", "")

        //    CarritoModels.Remove(SelectedItem);

        //    TotalCarrito = CalculateTotal();
        //}

        public double CalculateTotal()
        {
            double value = 0;

            foreach (GuitarModel model in CarritoModels)
            {
                value += model.Price;
            }

            return value;
        } 
    }
}
