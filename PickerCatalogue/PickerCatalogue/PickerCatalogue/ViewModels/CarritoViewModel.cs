using PickerCatalogue.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace PickerCatalogue.ViewModels
{
    public class CarritoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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

        public CarritoViewModel(INavigation navigationService)
        {
            _navigationService = navigationService;
            TotalCarrito = 0;
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

        //public override void Prepare(DTO parameter)
        //{
        //    Dto = parameter;
        //    CarritoModels = parameter.CarritoModels;

        //    TotalCarrito = CalculateTotal();
        //}
    }
}
