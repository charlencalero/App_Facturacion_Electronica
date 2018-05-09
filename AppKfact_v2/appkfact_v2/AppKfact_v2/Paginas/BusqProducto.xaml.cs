using AppEntidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppKfact_v2.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BusqProducto : ContentPage
    {
        public BusqProducto()
        {
            InitializeComponent();

            ObservableCollection<Producto> productos = new ObservableCollection<Producto>();

            productos.Add(new Producto("P0001", "CELULAR AKITA", "UNID", "22.3", "20"));
            productos.Add(new Producto("P0001", "CELULAR NOKIA", "UNID", "22.3", "20"));
            productos.Add(new Producto("P0001", "CELULAR SAMSUNG", "UNID", "22.3", "20"));
            productos.Add(new Producto("P0001", "CELULAR IPHONE", "UNID", "22.3", "20"));

            ListDetalle.ItemsSource = productos;

        }
    }
}