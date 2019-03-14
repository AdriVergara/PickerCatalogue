using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PickerCatalogue.Widgets
{
    public class CommandListView : ListView
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(CommandListView), null);

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public CommandListView()
        {
            ItemSelected += SendCommand;
        }

        private void SendCommand(object sender, EventArgs e)
        {
            if (SelectedItem == null) return;
            Command?.Execute(this.SelectedItem);
            SelectedItem = null;
        }
    }
}
