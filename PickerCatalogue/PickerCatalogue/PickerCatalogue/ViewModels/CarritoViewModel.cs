using PickerCatalogue.Models;
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

        public ICommand DeleteCartProductCommand { get; set; }

        public CarritoViewModel(INavigation navigation, ObservableCollection<GuitarModel> carrito)
        {
            _navigationService = navigation;
            CarritoModels = carrito;

            TotalCarrito = CalculateTotal();

            DeleteCartProductCommand = new Command(async () => await ExecuteDeleteCartProductCommand());
        }

        private async Task ExecuteDeleteCartProductCommand()
        {
            //await CrossNotifications.Current.Send("Deleting item", "")

            CarritoModels.Remove(SelectedItem);

            TotalCarrito = CalculateTotal();
        }

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
