using System;
using System.Collections.Generic;
using System.Text;

namespace AppEntity
{
    public class Cliente
    {
        public Cliente()
        { }

        public Cliente(int id,string tipodocu, string nombres, string direccion, string email, string celular)
        {
            Id = id;
            this.tipodocu = tipodocu;
            this.nombres = nombres;
            this.direccion = direccion;
            this.email = email;
            this.celular = celular;
        }

        public int Id { get; set; }
        public string tipodocu { get; set; }
        public string nombres { get; set; }
        public string direccion { get; set; }
        public string email { get; set; }
        public string celular { get; set; }
    }
}
