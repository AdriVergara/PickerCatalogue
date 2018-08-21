using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PickerCatalogue.Models
{
    public class GuitarModel
    {
        //public string ModelName { get; set; }
        //public ObservableCollection<string> Models { get; set; }
        //public string ImagePath { get; set; }

        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public ObservableCollection<GuitarImage> ImagesCollection { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
