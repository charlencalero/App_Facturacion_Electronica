using AppEntity;
using AppMovilFE.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMovilFE.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductosPg : ContentPage
	{
        private EntityFrameworkService _entityFrameworkService;


        public ProductosPg ()
		{
			
            InitializeComponent ();

            combounidad.Items.Add("NIU");
            combounidad.Items.Add("ZZ");

           
        }

      

        private async void cmd_grabar()
        {
           _entityFrameworkService = new EntityFrameworkService();

            try
            {
                var producto = new Producto();

                producto.Id = 0;
                producto.prod_descr = textcantidad.Text;
                producto.prod_unid = combounidad.SelectedItem.ToString();
                producto.prod_stock = textcantidad.Text;
                producto.prod_precio = textprecio.Text;

              

             
                textcodigo.Text = "";
                textnombre.Text = "";
                textprecio.Text = "";
                textcantidad.Text = "";
              
               _entityFrameworkService.ProductoInse(producto);

  await   DisplayAlert("System", "Producto agregado con exito", "ok");
                //Alerta.Text = "Producto agregado con exito";


            }
            catch (Exception ex)
            {

              await  DisplayAlert("System", ex.Message, "ok");
            }
        }
        private void cmd_nuevo()
        {
            textcodigo.Text = "";
            textnombre.Text = "";
            textprecio.Text = "";
            textcantidad.Text = "";
       
        }
        private void cmd_listar()
        {
            ObservableCollection<Producto> producto = new ObservableCollection<Producto>();
            _entityFrameworkService = new EntityFrameworkService();

           var prod=_entityFrameworkService.ProductoAll();

            for (int i = 0; i < prod.Count; i++)
            {
                producto.Add(new Producto(prod[i].Id, prod[i].prod_codi, prod[i].prod_descr, prod[i].prod_unid, prod[i].prod_precio, prod[i].prod_stock));
            }
         

            ListDetalle.ItemsSource = producto;
        }
    }
}