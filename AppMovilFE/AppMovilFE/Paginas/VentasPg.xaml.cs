using AppEntity;
using AppMovilFE.Data;
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

    private EntityFrameworkService _entityFrameworkService = new EntityFrameworkService();

        public VentasPg()
        {
            InitializeComponent();
            cargar();

            emi.tipoDocId = "6";
            emi.numeroDocId = "20542471256";
            emi.nombreComercial = "INGENIERIA E INFORMATICA KING SOFTWARE SAC";
            emi.razonSocial = "KSOFT";
            emi.ubigeo = "150131";
            emi.direccion = "A.H. BELLA DURMIENTE MZ B LOTE 19";
            emi.urbanizacion = "";
            emi.provincia = "HUANUCO";
            emi.distrito = "HUANUCO";
            emi.departamento = "HUANUCO";
            emi.codigoPais = "PE";
            emi.telefono = "998887099";
            emi.correoElectronico = "charlen.calero@gmail.com";

            var item = new Serie(10,"Xmm2", "exo", "BOLETA", "01");

        _entityFrameworkService.SerieInse(item);
            var result = _entityFrameworkService.SerieAll();

        }

        List<combo> comprobante = new List<combo>();
        List<Serie> serie = new List<Serie>();
        List<combo> tipodocu = new List<combo>();

        private void obtener_numero()
        {
           
            TextNumero.Text = _entityFrameworkService.ComprobanteMax("B001","03");

        }

        private void cargar_serie()
        {
           string comp =CombComp.SelectedItem.ToString();

            if (comp == "BOLETA")
            {
                CombTipoDocu.SelectedItem = "OTROS";
                TextDni.Text = "0";
                TextNombre.Text = "CLIENTE VARIOS";
                TextDireccion.Text = "-";
            }

            CombSerie.Items.Clear();

           for (int i = 0; i < serie.Count; i++)
           {
                if ( comp== serie[i].tipocomp)
                {
                 CombSerie.Items.Add(serie[i].descripcion);
            }
               
           }
        }

        private async void BuscarCliente()
        {
         

            List<string> myList = new List<string>();

            myList.Add("calero");
            myList.Add("maximo");
            myList.Add("charlen");

            string[] myArray = myList.ToArray();

          var action = await DisplayActionSheet("hola", "ok", null, myArray);

            var id = myList.IndexOf(action);

        }

        private void cargar()
        {
            comprobante.Add(new combo("01", "FACTURA"));
            comprobante.Add(new combo("03", "BOLETA"));

            serie.Add(new Serie(0,"B001", "IGV","BOLETA","10"));
            serie.Add(new Serie(0,"B002", "EXO","BOLETA","20"));
            serie.Add(new Serie(0,"B003", "INA", "BOLETA", "30"));
            serie.Add(new Serie(0,"F002", "IGV", "FACTURA", "10"));
            serie.Add(new Serie(0,"F003", "EXO", "FACTURA", "20"));

            tipodocu.Add(new combo("1", "DNI"));
            tipodocu.Add(new combo("6", "RUC"));
            tipodocu.Add(new combo("4", "CE"));
            tipodocu.Add(new combo("0", "OTROS"));


          

            for (int i = 0; i < comprobante.Count; i++)
            {
                CombComp.Items.Add(comprobante[i].descripcion);
            }

            for (int i = 0; i < tipodocu.Count; i++)
            {
                CombTipoDocu.Items.Add(tipodocu[i].descripcion);
            }

            //for (int i = 0; i < serie.Count; i++)
            //{
            //    CombSerie.Items.Add(serie[i].descripcion);
            //}


        }


       

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

            detalle.Add(new DLL_KS_OSE.Entity.Detalle("-", TextServDetalle.Text, "NIU", TextPrecio.Text, "0", TextCantidad.Text, "0",serie[CombSerie.SelectedIndex].tipoigv , "0", "-"));

            ListDetalle.ItemsSource = detalle;



            BindingContext = this;

            double total = (double.Parse(TextTotal.Text) + (double.Parse(TextPrecio.Text) * double.Parse(TextCantidad.Text)));
            TextTotal.Text = total.ToString();
            TextIgv.Text = (total / 1.18).ToString("0.00");
            TextSubtotal.Text = (total * 0.82).ToString();

            TextPrecio.Text = "";
            TextCantidad.Text = "";
            TextServDetalle.Text = "";

            prod_busca.IsVisible = true;
            prod_libre.IsVisible = false;
        }



        private void Button_Clicked(object sender, EventArgs e)
        {
            if (restriccion() == false) { return; }
            procesar();
        }


        private bool restriccion()
        {
            if (detalle.Count == 0 || detalle == null)
            {
                DisplayAlert("system", "No tiene ningun Detalle", "ok");
                return false;
            }

            try
            {
                if (int.Parse(TextNumero.Text) == 0)
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

        ObservableCollection<DLL_KS_OSE.Entity.Detalle> detalle = new ObservableCollection<DLL_KS_OSE.Entity.Detalle>();
        Integracion_EsconDatagate.Entity.EMI emi = new Integracion_EsconDatagate.Entity.EMI() ;

        private async void procesar()
        {
           

          DLL_KS_OSE.Entity.Comprobante comp = new DLL_KS_OSE.Entity.Comprobante() ;
         


            List<DLL_KS_OSE.Entity.Detalle> detacomp = new List<DLL_KS_OSE.Entity.Detalle>();

            foreach (var item in detalle)
            {
                detacomp.Add(item);
            }


            comp.codi_cab = "0";
            comp.esta_pod = "0";
            comp.codi_caja = "id dispo";
            comp.comp = comprobante[CombComp.SelectedIndex].codigo;
            comp.serie = serie[CombSerie.SelectedIndex].descripcion;
            comp.nume = TextNumero.Text;
            comp.fecha = DateFecha.Date.ToString("yyyy-MM-dd HH:mm:ss");
            comp.codi_vend = "iddisp";
            comp.clie_tipo = tipodocu[CombTipoDocu.SelectedIndex].codigo;
            comp.clie_docu = TextDni.Text;
            comp.clie_nomb = TextNombre.Text;
            comp.clie_dire = TextDireccion.Text;
            comp.clie_email = TextDireccion.Text;
            comp.clie_celu = "";
            comp.dire_entr = "";
            comp.ubig_entr = "";
            comp.mone_codi = "PEN";
            comp.tipo_igv = serie[CombSerie.SelectedIndex].tipocomp;
            comp.desc_globa = "";
            comp.obse = "";
            comp.guia = "";
            comp.placa = "";
            comp.codi_moti = "";
            comp.motivo = "";
            comp.doc_refe = "";
            comp.valorresumen = "";
            comp.valorhash = "";

            comp.gravado = "0.00";
            comp.exonerado = "0.00";
            comp.inafecto = "0.00";

            switch (serie[CombSerie.SelectedIndex].tipocomp)
            {
                case "IGV":
             comp.gravado = double.Parse(TextSubtotal.Text).ToString("0.00");
                    break;
                case "EXO":
            comp.inafecto = double.Parse(TextSubtotal.Text).ToString("0.00");
                    break;
                case "INA":
            comp.exonerado = double.Parse(TextSubtotal.Text).ToString("0.00");
                    break;
                default:
                    break;
            }
                       
            

            comp.igv = TextIgv.Text;
            comp.total = TextTotal.Text;
            comp.percepcion = "0";
            comp.detalle = detacomp;


            //  await api.EnviarComprobante(comp);

            DLL_KS_OSE.Bussines.CrearComp crear = new DLL_KS_OSE.Bussines.CrearComp();

            await   DisplayAlert("SYSTEM", crear.Crear(comp, emi),"OK");

            //INSERTAR BD

            var complocal = new Comprobante();
            complocal.comp = comp.comp;
            complocal.serie = comp.serie;
            complocal.nume = comp.nume;
           
            _entityFrameworkService.ComprobanteInse(complocal);

        }

        private async void BuscProd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BuscarProductoPg());
        }

        private async void BuscCode_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BuscarProductoPg());
        }

        private  void BuscLibre_Clicked(object sender, EventArgs e)
        {
            prod_busca.IsVisible = false;
            prod_libre.IsVisible = true;
        }
    }
}