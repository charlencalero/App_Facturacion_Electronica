
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppEntidades;
using AppKfact_v2.Data;

namespace AppKfact_v2.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]


public partial class VentasPg : ContentPage
    {

    public class combo
    {
            public combo(string codigo, string descripcion)
            {
                this.codigo = codigo;
                this.descripcion = descripcion;
            }

        public string codigo { get; set; }
        public string descripcion { get; set; }
    }

    public VentasPg()
        {
            InitializeComponent();
            cargar();
        }

        List<combo> comprobante = new List<combo>();
        List<combo> serie = new List<combo>();
        List<combo> tipodocu = new List<combo>();

        private void cargar()
        {
            comprobante.Add(new combo("01", "FACTURA"));
            comprobante.Add(new combo("03", "BOLETA"));

            serie.Add(new combo("IGV", "B001"));
            serie.Add(new combo("EXO", "B002"));

            tipodocu.Add(new combo("1", "DNI"));
            tipodocu.Add(new combo("6", "RUC"));
            tipodocu.Add(new combo("4", "CE"));
            tipodocu.Add(new combo("-", "OTROS"));


            for (int i = 0; i < comprobante.Count; i++)
            {
              CombComp.Items.Add(comprobante[i].descripcion);
            }

            for (int i = 0; i < tipodocu.Count; i++)
            {
                CombTipoDocu.Items.Add(tipodocu[i].descripcion);
            }

            for (int i = 0; i < serie.Count; i++)
            {
                CombSerie.Items.Add(serie[i].descripcion);
            }
          

        }


        ObservableCollection<Detalle> detalle = new ObservableCollection<Detalle>();

        private void ButtAgregar_Clicked(object sender, EventArgs e)
        {

            if (CombSerie.SelectedIndex < 0)
            {
                DisplayAlert("system", "Seleccione una Serie Valida", "ok");
                return;
            }

            if (TextServDetalle.Text == "" || TextServDetalle.Text == null)
            {
                DisplayAlert("system", "Ingrese una descripcion para el Detalle", "ok");
                return;
            }

            if (TextCantidad.Text == "" || TextCantidad.Text == null)
            {
                DisplayAlert("system", "Ingrese una descripcion para el Detalle", "ok");
                return;
            }

            if (TextPrecio.Text == "" || TextPrecio.Text == null)
            {
                DisplayAlert("system", "Ingrese una descripcion para el Detalle", "ok");
                return;
            }

            detalle.Add(new Detalle( "-", TextServDetalle.Text,"NIU", TextPrecio.Text,"0", TextCantidad.Text,"0", serie[CombSerie.SelectedIndex].codigo, "0", "-"));

            ListDetalle.ItemsSource = detalle;



            BindingContext = this;

            double total = (double.Parse(TextTotal.Text) + (double.Parse(TextPrecio.Text) * double.Parse(TextCantidad.Text)));
            TextTotal.Text = total.ToString();
            TextIgv.Text = (total / 1.18).ToString("0.00");
            TextSubtotal.Text = (total * 0.82).ToString();

            TextPrecio.Text = "";
            TextCantidad.Text = "";
            TextServDetalle.Text = "";

        }

 

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (restriccion() == false) { return; }
            procesar();
        }


        private bool restriccion()
        {
            if (detalle.Count == 0 || detalle== null)
            {
                DisplayAlert("system", "No tiene ningun Detalle", "ok");
                return false;
            }

            try
            {
             if ( int.Parse(TextNumero.Text)==0)
            {
                DisplayAlert("system", "Ingrese un numero de serie", "ok");
                return false;
            }
            }
            catch (Exception)
            {
                DisplayAlert("system", "Ingrese un numero de serie", "ok");
                return false;
            }
         

            if (CombTipoDocu.SelectedIndex == -1)
            {
                DisplayAlert("system", "Seleccione un tipo de documento", "ok");
                return false;
            }


            if (CombComp.SelectedIndex == -1)
            {
                DisplayAlert("system", "Seleccione un tipo de Comprobante", "ok");
                return false;
            }


            if (CombSerie.SelectedIndex == -1)
            {
                DisplayAlert("system", "Seleccione una Serie", "ok");
                return false;
            }

            if (TextDni.Text == "")
            {
                DisplayAlert("system", "Ingrese un numero de documento", "ok");
                return false;
            }

            if (TextDireccion.Text == "")
            {
                DisplayAlert("system", "Ingrese una Direccion", "ok");
                return false;
            }

            return true;

        }

        private async void procesar()
        {
            ApiAcces api = new ApiAcces();
            Comprobante comp = new Comprobante();
            List<AppEntidades.Detalle> detacomp= new List<AppEntidades.Detalle>();

            foreach (var item in detalle)
            {
                detacomp.Add(item);
            }


            comp.codi_cab = "0";
            comp.esta_pod = "0";
            comp.codi_caja = "id dispo";
            comp.comp = comprobante[CombSerie.SelectedIndex].codigo;
            comp.serie = serie[CombSerie.SelectedIndex].descripcion;
            comp.nume = TextNumero.Text;
            comp.fecha = DateFecha.ToString();
            comp.codi_vend = "iddisp";
            comp.clie_tipo = tipodocu[CombTipoDocu.SelectedIndex].codigo;
            comp.clie_docu = TextDni.Text;
            comp.clie_nomb = TextNombre.Text;
            comp.clie_dire = TextDireccion.Text;
            comp.clie_email = TextDireccion.Text;
            comp.clie_celu = "";
            comp.dire_entr = "";
            comp.ubig_entr = "";
            comp.mone_codi = "PE";
            comp.tipo_igv = "SI";
            comp.desc_globa = "";
            comp.obse = "";
            comp.guia = "";
            comp.placa = "";
            comp.codi_moti = "";
            comp.motivo = "";
            comp.doc_refe = "";
            comp.valorresumen = "";
            comp.valorhash = "";


            comp.gravado = "";
            comp.inafecto = "";
            comp.exonerado = "";

            comp.igv = TextIgv.Text;
            comp.total = TextTotal.Text;
            comp.percepcion = "0";
            comp.detalle = detacomp;


          await  api.EnviarComprobante(comp);


        }

        private async void BuscProd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BusqProducto());
        }
    }
}