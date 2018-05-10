using System;
using System.Collections.Generic;
using System.Text;

namespace AppEntity
{
   public  class Producto
    {
        public Producto()
        {

        }

        public Producto(string prod_codi, string prod_descr, string prod_unid, string prod_precio, string prod_stock)
        {
            this.prod_codi = prod_codi;
            this.prod_descr = prod_descr;
            this.prod_unid = prod_unid;
            this.prod_precio = prod_precio;
            this.prod_stock = prod_stock;
        }

        public string prod_codi { get; set; }
        public string prod_descr { get; set; }
        public string prod_unid { get; set; }
        public string prod_precio { get; set; }
        public string prod_stock { get; set; }

    }
}
