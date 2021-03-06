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
	public partial class ClientesPg : ContentPage
	{
		public ClientesPg ()
		{
			InitializeComponent ();
            combotipodocu.Items.Add("DNI");
            combotipodocu.Items.Add("RUC");
            combotipodocu.Items.Add("CE");
            combotipodocu.Items.Add("PASAPORTE");
        }

        private EntityFrameworkService _entityFrameworkService;

        private async void cmd_grabar()
        {
            _entityFrameworkService = new EntityFrameworkService();
            DataAcces data = new DataAcces();

            try
            {
                var cliente = new Cliente();

              
                cliente.tipodocu =combotipodocu.SelectedItem.ToString();
                cliente.nombres = textnombre.Text;
                cliente.documento = textdocu.Text;
                cliente.direccion = textdireccion.Text;
                cliente.email = textemail.Text;
                cliente.celular = textcelular.Text;
              
                textdireccion.Text = "";
                textnombre.Text = "";
                textdocu.Text = "";
                textemail.Text = "";
                textcelular.Text = "";

                // _entityFrameworkService.ClienteInse(cliente);

                data.Insert<Cliente>(cliente);

                await DisplayAlert("System", "Cliente agregado con exito", "ok");
                //Alerta.Text = "Producto agregado con exito";
                var result = data.GetList<Cliente>(false);

            }
            catch (Exception ex)
            {

                await DisplayAlert("System", ex.Message, "ok");
            }
        }
        private void cmd_nuevo()
        {
            textdireccion.Text = "";
            textnombre.Text = "";
            textemail.Text = "";
            textcelular.Text = "";
            textdocu.Text = "";
        }
       
    }
}