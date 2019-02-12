using System;
using System.Collections;
using System.Collections.Specialized;
using System.Windows.Input;
using Xamarin.Forms;

namespace PickerCatalogue.Controls
{
    public class CommandListView : ListView
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(CommandListView), null);

        public static readonly BindableProperty ListEmptyProperty =
            BindableProperty.Create("ListEmpty", typeof(bool), typeof(CommandListView), false);

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }
        public bool ListEmpty
        {
            get => (bool)GetValue(ListEmptyProperty);
            set => SetValue(ListEmptyProperty, value);
        }

        public CommandListView()
        {
            ItemTapped += SendCommand;
        }
        public CommandListView(ListViewCachingStrategy cachingStrategy):base(cachingStrategy)
        {
            ItemTapped += SendCommand;
        }

        private void SendCommand(object sender, ItemTappedEventArgs e)
        {
            Command?.Execute(SelectedItem);
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            if (propertyName == CommandListView.ItemsSourceProperty.PropertyName)
            {
                if (ItemsSource != null && ItemsSource is INotifyCollectionChanged collection)
                {
                    collection.CollectionChanged -= ItemsSourceCollectionChanged;
                    collection.CollectionChanged += ItemsSourceCollectionChanged;
                    ChangeVisibility();
                }
            }
            base.OnPropertyChanged(propertyName);
        }


        private void ChangeVisibility()
        {
            var itemsList = (IList)this.ItemsSource;
            if (itemsList == null || itemsList.Count == 0)
            {
                ListEmpty = true;
                IsVisible = false;
            }
            else
            {
                ListEmpty = false;
                IsVisible = true;
            }
        }

        private void ItemsSourceCollectionChanged(object s, EventArgs e)
        {
            ChangeVisibility();
        }

    }
}