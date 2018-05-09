using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppKfact.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VentasPg : ContentPage
    {
        public VentasPg()
        {
            InitializeComponent();

            CombComp.Items.Add("Boleta");
            CombComp.Items.Add("Factura");

            CombSerie.Items.Add("B001");
            CombSerie.Items.Add("F001");


        }
    }
}
