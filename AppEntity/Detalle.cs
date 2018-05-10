using System;
using System.Collections.Generic;
using System.Text;

namespace AppEntity
{
   public class Detalle
    {
        public Detalle()
        { }

        public Detalle(string prod_codi, string prod_descr, string prod_unid, string prod_precio, string prod_desct, string prod_cant, string codi_cab, string tipo_igv, string percepcion, string obse)
        {
            this.prod_codi = prod_codi;
            this.prod_descr = prod_descr;
            this.prod_unid = prod_unid;
            this.prod_precio = prod_precio;
            this.prod_desct = prod_desct;
            this.prod_cant = prod_cant;
            this.codi_cab = codi_cab;
            this.tipo_igv = tipo_igv;
            this.percepcion = percepcion;
            this.obse = obse;
        }

        public string prod_codi { get; set; }
        public string prod_descr { get; set; }
        public string prod_unid { get; set; }
        public string prod_precio { get; set; }
        public string prod_desct { get; set; }
        public string prod_cant { get; set; }
        public string codi_cab { get; set; }
        public string tipo_igv { get; set; }
        public string percepcion { get; set; }
        public string obse { get; set; }
    }
}
