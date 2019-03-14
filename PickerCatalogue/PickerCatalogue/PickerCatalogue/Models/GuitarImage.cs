using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using PickerCatalogue.ViewModels;
using System.Threading.Tasks;

namespace PickerCatalogue.Models
{
    public class GuitarImage
    {
        public int Id { get; set; }
        public string Image { get; set; }

        public Command ImageZoomCommand { get; set; }
        public EventHandler TapClickEventHandler;

        public GuitarImage()
        {
            TapClickEventHandler = OnTapped;
            ImageZoomCommand = new Command(() => OnImageClicked());
        }

        public void OnImageClicked()
        {
            TapClickEventHandler?.Invoke(this, EventArgs.Empty);
        }

        void OnTapped(object sender, EventArgs e)
        {
            GuitarImage GuitarImg = (GuitarImage)sender;
            string GuitarName = GuitarImg.Image;

            Task.Run(() => ShowGuitarModelViewModel.testt(GuitarName)).Wait();
        }
    }
}