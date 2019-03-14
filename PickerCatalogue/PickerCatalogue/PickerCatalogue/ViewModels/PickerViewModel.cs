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
using System.Linq;

namespace PickerCatalogue.ViewModels
{
    public class PickerViewModel : BaseViewModel
    {
        public ICommand VisitGuitarModel { get; set; }
        public ICommand NextPageParam { get; set; }
        public ICommand GoToCarrito { get; set; }
        public ICommand ChangeOrderDirection { get; set; }

        //private ICommand _searchCommand;
        //public ICommand SearchCommand
        //{
        //    get
        //    {
        //        return _searchCommand ?? (_searchCommand = new Command<string>((text) =>
        //        {
        //            // The text parameter can now be used for searching.
        //            text += "-";
        //        }));
        //    }
        //}

        public ObservableCollection<GuitarModel> CarritoModels { get; set; }

        private ObservableCollection<GuitarModel> _productsToShow { get; set; }
        public ObservableCollection<GuitarModel> ProductsToShow
        {
            get
            {
                return _productsToShow;
            }
            set
            {
                _productsToShow = value;
                OnPropertyChanged("ProductsToShow");
            }
        }

        private ObservableCollection<string> _filterByOptions { get; set; }
        public ObservableCollection<string> FilterByOptions
        {
            get
            {
                return _filterByOptions;
            }
            set
            {
                _filterByOptions = value;
                OnPropertyChanged("FilterByOptions");
            }
        }

        private int _orderDirection = 1;
        public int OrderDirection
    {
            get
            {
                return _orderDirection;
            }
            set
            {
                _orderDirection = value;
                OnPropertyChanged("OrderDirection");
                FilterProductsList();
            }
        }

        string _selectedFilter = "Brand";
        public string SelectedFilter
        {
            get
            {
                return _selectedFilter;
            }
            set
            {
                //if (SetProperty(ref _selectedFilter, value))
                _selectedFilter = value;
                OnPropertyChanged("SelectedFilter");
                FilterProductsList();
            }
        }

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

            FilterByOptions = new ObservableCollection<string>() { "Brand", "Price", "Stock", "Rating" };

            //SelectedFilter = "Brand";
            //Visible = "False";

            _brandsService = new BrandsService();
            BrandsToShow = new ObservableCollection<Brand>();
            ProductsToShow = new ObservableCollection<GuitarModel>();
            ModelSelected = new GuitarModel();

            InitializeBrandsAndModels();
            ProductsToShow = InitializeAllProductsCollection();

            //FilterProductsList();

            VisitGuitarModel = new Command(async () => await ExecuteVisitGuitarModel());
            //NextPageParam = new Command(async (Param) => await ExecuteNextPage(Param));
            GoToCarrito = new Command(async () => await ExecuteGoToCarrito());
            ChangeOrderDirection = new Command(async () => await ExecuteChangeOrderDirection());
        }

        private async Task ExecuteChangeOrderDirection()
        {
            OrderDirection *= -1;
        }

        private void FilterProductsList()
        {
            switch (SelectedFilter)
            {
                case "Price" : FilterByPrice();
                    break;
                case "Brand" : FilterByBrand();
                    break;
                case "Stock" : FilterByStock();
                    break;
                case "Rating": FilterByRating();
                    break;
            }
        }

        private void FilterByRating()
        {
            ObservableCollection<GuitarModel> OrderedCollection = new ObservableCollection<GuitarModel>();
            List<GuitarModel> OrderedList = ProductsToShow.ToList();

            if (OrderDirection == 1)
            {
                OrderedList = OrderedList.OrderBy(i => i.Rating).ToList();
            }
            else if(OrderDirection == -1)
            {
                OrderedList = OrderedList.OrderByDescending(i => i.Rating).ToList();
            }

            foreach (GuitarModel model in OrderedList)
            {
                OrderedCollection.Add(model);
            }

            ProductsToShow = OrderedCollection;
        }

        private void FilterByPrice()
        {
            ObservableCollection<GuitarModel> OrderedCollection = new ObservableCollection<GuitarModel>();
            List<GuitarModel> OrderedList = ProductsToShow.ToList();

            if (OrderDirection == 1)
            {
                OrderedList = OrderedList.OrderBy(i => i.Price).ToList();
            }
            else if (OrderDirection == -1)
            {
                OrderedList = OrderedList.OrderByDescending(i => i.Price).ToList();
            }

            foreach (GuitarModel model in OrderedList)
            {
                OrderedCollection.Add(model);
            }

            ProductsToShow = OrderedCollection;
        }

        private void FilterByBrand()
        {
            ObservableCollection<GuitarModel> OrderedCollection = new ObservableCollection<GuitarModel>();
            List<GuitarModel> OrderedList = ProductsToShow.ToList();

            if (OrderDirection == 1)
            {
                OrderedList = OrderedList.OrderBy(i => i.BrandName).ToList();
            }
            else if (OrderDirection == -1)
            {
                OrderedList = OrderedList.OrderByDescending(i => i.BrandName).ToList();
            }

            foreach (GuitarModel model in OrderedList)
            {
                OrderedCollection.Add(model);
            }

            //OrderedCollection.Add(OrderedList[0]);
            //OrderedCollection.Add(OrderedList[2]);
            //OrderedCollection.Add(OrderedList[3]);

            ProductsToShow = OrderedCollection;
        }

        private void FilterByStock()
        {
            ObservableCollection<GuitarModel> OrderedCollection = new ObservableCollection<GuitarModel>();
            List<GuitarModel> OrderedList = ProductsToShow.ToList();

            if (OrderDirection == 1)
            {
                OrderedList = OrderedList.OrderBy(i => i.Stock).ToList();
            }
            else if (OrderDirection == -1)
            {
                OrderedList = OrderedList.OrderByDescending(i => i.Stock).ToList();
            }

            foreach (GuitarModel model in OrderedList)
            {
                OrderedCollection.Add(model);
            }

            ProductsToShow = OrderedCollection;
        }

        private ObservableCollection<GuitarModel> InitializeAllProductsCollection()
        {
            ObservableCollection<GuitarModel> NewCollection = new ObservableCollection<GuitarModel>();

            foreach (Brand brand in BrandsToShow)
            {
                foreach (GuitarModel model in brand.Models)
                {
                    NewCollection.Add(model);
                }
            }
            return NewCollection;
        }

        //private Task ExecuteNextPage(object param)
        //{
        //    //
        //}

        private async Task ExecuteGoToCarrito()
        {
            await _navigationService.PushAsync(new CarritoView(CarritoModels));
        }

        private async Task ExecuteVisitGuitarModel()
        {
            await _navigationService.PushAsync(new ShowGuitarModelView(ModelSelected, CarritoModels));
        }

        private void InitializeBrandsAndModels()
        {
            BrandsToShow = _brandsService.GetBrands();  
        }
    }
}
