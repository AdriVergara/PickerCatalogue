using Acr.UserDialogs;
using PickerCatalogue.Models;
using PickerCatalogue.Views;
using System.Collections.ObjectModel;
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

        public GuitarModel Selection { get; set; }

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
                    Selection = (GuitarModel)e;

                    var a = DeleteCartProduct(Selection);
                });
            }
        }

        public CarritoViewModel(INavigation navigation, ObservableCollection<GuitarModel> carrito)
        {
            _navigationService = navigation;

            CarritoModels = carrito;

            TotalCarrito = CalculateTotal();
        }

        private async Task DeleteCartProduct(GuitarModel selection)
        {
            bool result = await UserDialogs.Instance.ConfirmAsync(new ConfirmConfig
            {
                Title = "Deleting Product from cart",
                Message = "Are you sure?",
                OkText = "Delete",
                CancelText = "Cancel"
            });

            if (result)
            {
                CarritoModels.Remove(selection);
                TotalCarrito = CalculateTotal();
            }
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
