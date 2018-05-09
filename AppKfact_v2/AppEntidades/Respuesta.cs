using System;
using System.Collections.Generic;
using System.Text;

namespace AppEntidades
{
    public class Respuesta
    {
        public Respuesta()
        {

        }

        public Respuesta(string mensaje, string error)
        {
            this.mensaje = mensaje;
            this.error = error;
        }

        public string mensaje { get; set; }
        public string error { get; set; }

    }
}
