using System;
using System.Collections.Generic;
using System.Text;

namespace AppEntity
{
    public class Serie
    {
        public Serie()
            {}

        public Serie(string descripcion, string tipoigv, string tipocomp, string tipoafectacion)
        {
            this.descripcion = descripcion;
            this.tipoigv = tipoigv;
            this.tipocomp = tipocomp;
            this.tipoafectacion = tipoafectacion;
        }

        public string descripcion { get; set; }
        public string tipoigv { get; set; }
        public string tipocomp { get; set; }
        public string tipoafectacion { get; set; }

    }
}
