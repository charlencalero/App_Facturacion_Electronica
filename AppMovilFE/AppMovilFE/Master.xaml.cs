using AppMovilFE.Paginas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMovilFE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : ContentPage
    {
        public Master()
        {
            InitializeComponent();
            var masterPageItems = new List<MasterPageItem>();

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Ventas",
                IconSource = "confi_icon.png",
                TargetType = typeof(VentasPg)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Series",
                IconSource = "confi_icon.png",
                TargetType = typeof(SeriesPg)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Clientes",
                IconSource = "confi_icon.png",
                TargetType = typeof(ClientesPg)
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "Productos",
                IconSource = "confi_icon.png",
                TargetType = typeof(ProductosPg)
            });

            listView.ItemsSource = masterPageItems;


        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                //var page = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                App.MasterDetail.Detail.Navigation.PushAsync((Page)Activator.CreateInstance(item.TargetType));
                listView.SelectedItem = null;
                App.MasterDetail.IsPresented = false;
            }
        }
    }
}