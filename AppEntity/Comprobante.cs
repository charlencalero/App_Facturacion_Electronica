using System;
using System.Collections.Generic;
using System.Text;

namespace AppEntity
{
    public class Comprobante
    {
        public Comprobante()
        {
            // this.factguia = new FacturaGuia();
            //  this.detalle = new List<Detalle>();
        }

        public Comprobante(int Id, string esta_pod, string codi_caja, string comp, string serie, string nume, string fecha, string codi_vend, string clie_tipo, string clie_docu, string clie_nomb, string clie_dire, string clie_email, string clie_celu, string dire_entr, string ubig_entr, string mone_codi, string tipo_igv, string desc_globa, string obse, string guia, string placa, string codi_moti, string motivo, string doc_refe, string valorresumen, string valorhash, string gravado, string inafecto, string exonerado, string igv, string total, string percepcion)
            //, List<Detalle> detalle, FacturaGuia factguia)
        {
            this.Id = Id;
            this.esta_pod = esta_pod;
            this.codi_caja = codi_caja;
            this.comp = comp;
            this.serie = serie;
            this.nume = nume;
            this.fecha = fecha;
            this.codi_vend = codi_vend;
            this.clie_tipo = clie_tipo;
            this.clie_docu = clie_docu;
            this.clie_nomb = clie_nomb;
            this.clie_dire = clie_dire;
            this.clie_email = clie_email;
            this.clie_celu = clie_celu;
            this.dire_entr = dire_entr;
            this.ubig_entr = ubig_entr;
            this.mone_codi = mone_codi;
            this.tipo_igv = tipo_igv;
            this.desc_globa = desc_globa;
            this.obse = obse;
            this.guia = guia;
            this.placa = placa;
            this.codi_moti = codi_moti;
            this.motivo = motivo;
            this.doc_refe = doc_refe;
            this.valorresumen = valorresumen;
            this.valorhash = valorhash;
            this.gravado = gravado;
            this.inafecto = inafecto;
            this.exonerado = exonerado;
            this.igv = igv;
            this.total = total;
            this.percepcion = percepcion;
         //   this.detalle = detalle;
         //   this.factguia = factguia;
        }

        public int Id { get; set; }
        public String esta_pod { get; set; }
        public String codi_caja { get; set; }
        public String comp { get; set; }
        public String serie { get; set; }
        public String nume { get; set; }
        public String fecha { get; set; }
        public String codi_vend { get; set; }

        public String clie_tipo { get; set; }
        public String clie_docu { get; set; }
        public String clie_nomb { get; set; }
        public String clie_dire { get; set; }
        public String clie_email { get; set; }

        public String clie_celu { get; set; }
        public String dire_entr { get; set; }
        public String ubig_entr { get; set; }
        public String mone_codi { get; set; }

        public String tipo_igv { get; set; }
        public String desc_globa { get; set; }
        public String obse { get; set; }
        public String guia { get; set; }
        public String placa { get; set; }

        public String codi_moti { get; set; }
        public String motivo { get; set; }
        public String doc_refe { get; set; }

        public String valorresumen { get; set; }
        public String valorhash { get; set; }

        public String gravado { get; set; }
        public String inafecto { get; set; }
        public String exonerado { get; set; }
        public String igv { get; set; }
        public String total { get; set; }
        public String percepcion { get; set; }

      //  public List<Detalle> detalle { get; set; }

       // public FacturaGuia factguia { get; set; }

    }
}
