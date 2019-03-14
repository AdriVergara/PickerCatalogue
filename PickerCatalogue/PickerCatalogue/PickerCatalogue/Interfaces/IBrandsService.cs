using PickerCatalogue.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PickerCatalogue.Interfaces
{
    public interface IBrandsService
    {
        ObservableCollection<Brand> GetBrands();
    }
}
