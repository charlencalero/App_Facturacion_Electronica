using System;
using System.Collections.Generic;
using System.Text;

namespace AppEntidades
{
    public class FacturaGuia
    {
        public FacturaGuia()
        {
        }

        public FacturaGuia(string dire_part, string ubig_part, string dire_lleg, string ubig_lleg, string cod_Ubigeo, string tipo_trans, string peso_kg, string trans_publ_ruc, string trans_publ_razon, string trans_priv_placa, string trans_priv_marca, string trans_priv_const, string trans_priv_lice)
        {
            this.dire_part = dire_part;
            this.ubig_part = ubig_part;
            this.dire_lleg = dire_lleg;
            this.ubig_lleg = ubig_lleg;
            this.cod_Ubigeo = cod_Ubigeo;
            this.tipo_trans = tipo_trans;
            this.peso_kg = peso_kg;
            this.trans_publ_ruc = trans_publ_ruc;
            this.trans_publ_razon = trans_publ_razon;
            this.trans_priv_placa = trans_priv_placa;
            this.trans_priv_marca = trans_priv_marca;
            this.trans_priv_const = trans_priv_const;
            this.trans_priv_lice = trans_priv_lice;
        }

        public string dire_part { get; set; }
        public string ubig_part { get; set; }
        public string dire_lleg { get; set; }
        public string ubig_lleg { get; set; }
        public string cod_Ubigeo { get; set; }
        public string tipo_trans { get; set; }
        public string peso_kg { get; set; }
        public string trans_publ_ruc { get; set; }
        public string trans_publ_razon { get; set; }
        public string trans_priv_placa { get; set; }
        public string trans_priv_marca { get; set; }
        public string trans_priv_const { get; set; }
        public string trans_priv_lice { get; set; }
    }
}
