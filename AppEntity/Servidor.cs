using System;
using System.Collections.Generic;
using System.Text;

namespace AppEntity
{
    public class Servidor
    {
        public Servidor()
        { }

        public Servidor(string servidor, string url, string usuario, string clave)
        {
            this.servidor = servidor;
            this.url = url;
            this.usuario = usuario;
            this.clave = clave;
        }

        public string servidor { get; set; }
        public string url { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }
    }
}
