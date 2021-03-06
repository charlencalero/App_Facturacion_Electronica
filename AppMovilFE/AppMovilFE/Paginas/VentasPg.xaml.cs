﻿using AppEntity;
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

   // private EntityFrameworkService _entityFrameworkService ;
        DataAcces data = new DataAcces();
        private ScanService scanservice;
      private  Servidor ServidorEscon ;

        public VentasPg()
        {
            InitializeComponent();
            cargar();
            scanservice = new ScanService();
            ServidorEscon = new Servidor();

            ServidorEscon.servidor = "http://calidad.escondatagate.net";
            ServidorEscon.url = "/wsParser/rest/parserWS";
            //ServidorEscon.usuario = "20542471256King02";
            //ServidorEscon.clave = "King2018*";
            //emi.numeroDocId = "20542471256";

            ServidorEscon.usuario = "20557103920ad_escon";
            ServidorEscon.clave = "Escon2018*";
            emi.numeroDocId = "20557103920";

            emi.tipoDocId = "6";
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

       


        }

        List<combo> comprobante = new List<combo>();
        List<Serie> serie = new List<Serie>();
        List<combo> tipodocu = new List<combo>();

        private void obtener_numero()
        {
            //_entityFrameworkService = new EntityFrameworkService();

            // TextNumero.Text = _entityFrameworkService.ComprobanteMax(CombSerie.SelectedItem.ToString(), comprobante[CombSerie.SelectedIndex].codigo);

            TextNumero.Text = data.ComprobanteMax(CombSerie.SelectedItem.ToString(), comprobante[CombComp.SelectedIndex].codigo);
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
            if (CombTipoDocu.SelectedIndex < 0)
            {
             await   DisplayAlert("system", "Seleccione El Tipo de Documento", "ok");
                return;
            }

            if (TextDni.Text == "" || TextDni.Text == null)
            {
             await   DisplayAlert("system", "Ingrese una parametro a buscar", "ok");
                return;
            }

           // _entityFrameworkService = new EntityFrameworkService();

      //  var clie= _entityFrameworkService.ClienteDocu(CombTipoDocu.SelectedItem.ToString(), TextDni.Text);
          var clie= data.ClienteDocu(CombTipoDocu.SelectedItem.ToString(), TextDni.Text);

            if (clie != null)
            {
                TextDni.Text = clie.documento;
                TextNombre.Text = clie.nombres;
                TextDireccion.Text = clie.direccion;
                TextEmail.Text = clie.email;
                
            }
            else
            {
                var clientes = data.ClienteTexto(TextDni.Text);

                 List<string> myList = new List<string>();

             

                for (int i = 0; i < clientes.Count; i++)
                {
                 myList.Add(clientes[i].nombres);
                }
                 string[] myArray = myList.ToArray();

                if (clientes.Count != 0)
                {
                    var action = await DisplayActionSheet("Selecciona Cliente", "ok", null, myArray);

                    if (action != null)
                    {
                    var id = myList.IndexOf(action);
                        TextDni.Text = clientes[id].documento;
                    TextNombre.Text = clientes[id].nombres;
                    TextDireccion.Text = clientes[id].direccion;
                    TextEmail.Text = clientes[id].email;
                    }
                  
                }
                else
                {
                    await DisplayAlert("System","no se encontro ningun Cliente", "ok");
                }

            }


                    

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

            AgregarDetalle("-", TextServDetalle.Text, TextCantidad.Text, TextPrecio.Text,"NIU");
        }

        private void AgregarDetalle(string codigo,string descripcion,string cantidad,string precio,string unidad)
        {
            if (CombSerie.SelectedIndex < 0)
            {
                DisplayAlert("system", "Seleccione una Serie Valida", "ok");
                return;
            }

            if (descripcion == "" || descripcion == null)
            {
                DisplayAlert("system", "Ingrese una descripcion para el Detalle", "ok");
                return;
            }

            if (cantidad == "" || cantidad == null)
            {
                DisplayAlert("system", "Ingrese una descripcion para el Detalle", "ok");
                return;
            }

            if (precio == "" ||precio == null)
            {
                DisplayAlert("system", "Ingrese una descripcion para el Detalle", "ok");
                return;
            }

            detalle.Add(new DLL_KS_OSE.Entity.Detalle(codigo, descripcion, unidad, precio, "0",cantidad, "0", serie[CombSerie.SelectedIndex].tipoigv, "0", "-"));

            ListDetalle.ItemsSource = detalle;



            BindingContext = this;

            double total = (double.Parse(TextTotal.Text) + (double.Parse(precio) * double.Parse(cantidad)));
            TextTotal.Text = total.ToString();
            TextIgv.Text = (total-(total / 1.18)).ToString("0.00");
            TextSubtotal.Text = (total / 1.18).ToString("0.00");

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

           // _entityFrameworkService = new EntityFrameworkService();

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
            comp.clie_email = TextEmail.Text;
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



            comp.tipo_igv = serie[CombSerie.SelectedIndex].tipoigv;
            comp.montoafectado= double.Parse(TextSubtotal.Text).ToString("0.00");
            comp.igv = TextIgv.Text;
            comp.total = TextTotal.Text;
            comp.percepcion = "0";
            comp.detalle = detacomp;


            //  await api.EnviarComprobante(comp);

            DLL_KS_OSE.Bussines.CrearComp crear = new DLL_KS_OSE.Bussines.CrearComp();
            var resp =await crear.Crear(comp, emi,ServidorEscon.servidor,ServidorEscon.url,ServidorEscon.usuario,ServidorEscon.clave);
            await   DisplayAlert("SYSTEM", resp.responseContent,"OK");

            if (resp.responseCode == "0")
            {
DependencyService.Get<ISaveAndLoad>().SaveText(comp.serie+"-"+comp.nume+".zip", resp.details.cdr);

            //INSERTAR BD

            var complocal = new Comprobante();
            complocal.comp = comp.comp;
            complocal.serie = comp.serie;
            complocal.nume = int.Parse(comp.nume);

            data.Insert<Comprobante>(complocal);



            //var result = _entityFrameworkService.ComprobanteAll();
            obtener_numero();

            }

            
        }

        private  void BuscProd_Clicked(object sender, EventArgs e)
        {

           BuscarProducto(TextBuscProd.Text);

        }
        
        private async void BuscCode_Clicked(object sender, EventArgs e)
        {
            var code = await scanservice.ScannerQr();
            BuscarProducto(code.ToString());
        }

        private async void BuscarProducto(string filtro)
        {
            

            if (filtro == "" || filtro == null)
            {
               await DisplayAlert("system", "Ingrese una parametro a buscar", "ok");
                return;
            }

            //_entityFrameworkService = new EntityFrameworkService();

            var prod = data.ProductoCodi(filtro);

            if (prod != null)
            {
                AgregarDetalle(prod.prod_codi, prod.prod_descr, "1", prod.prod_precio, prod.prod_unid);

            }
            else
            {
                var productos= data.ProductoTexto(filtro);

           
                List<string> myList = new List<string>();

                for (int i = 0; i < productos.Count; i++)
                {
                    myList.Add(productos[i].prod_descr);
                }
                string[] myArray = myList.ToArray();

                if (productos.Count > 0)
                {
                    var action = await DisplayActionSheet("Selecciona Producto", "ok", null, myArray);
                    if (action != null)
                    {
                    var id = myList.IndexOf(action);
                    AgregarDetalle(productos[id].prod_codi, productos[id].prod_descr, "1", productos[id].prod_precio, productos[id].prod_unid);

                    }
               
                }
                else
                {
                    await DisplayAlert("SYSTEM","No se encontro ningun Producto", "ok");
                }
          
            }

        }

        private  void BuscLibre_Clicked(object sender, EventArgs e)
        {
            prod_busca.IsVisible = false;
            prod_libre.IsVisible = true;
        }
    }
}