using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PickerCatalogue.Models
{
    public class Brand
    {
        public string BrandName { get; set; }
        public ObservableCollection<GuitarModel> Models { get; set; }
        public string ImagePath { get; set; }
    }
}
