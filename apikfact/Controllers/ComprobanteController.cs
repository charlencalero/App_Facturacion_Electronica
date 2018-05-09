using AppEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiKfact.Controllers
{
    public class ComprobanteController : ApiController
    {

       // Data DB = new Data();
        string error;

        public Respuesta Post(Comprobante Comp)
        {
            Respuesta respuesta = new Respuesta();
          //  var resp = DB.pedido_agregar(Pedido);

            //if (resp == "")
            //{
            //    respuesta.error = DB.errorSQL;
            //    respuesta.mensaje = "no se pudo Registrar," + respuesta.error;
            //}
            //else
            //{
                respuesta.error = "null";
                respuesta.mensaje = "Registrado con Exito";
            //}


            return respuesta;
        }
    }
}
