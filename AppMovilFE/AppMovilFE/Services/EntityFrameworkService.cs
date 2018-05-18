using AppEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMovilFE.Services
{
    class EntityFrameworkService: IEntityFrameworkService
    {
        private static DatabaseContext _context;

        public EntityFrameworkService()
        {
            _context = new DatabaseContext();
        }

        #region Tabla Cliente

        public IList<Cliente> ClienteAll()
        {
            _context = new DatabaseContext();
            return _context.TablaCliente.ToList();
        }

        public Cliente ClienteDocu(string tipodoc,string docu)
        {
            return _context.TablaCliente.Where(p=> p.tipodocu==tipodoc && p.documento==docu ).FirstOrDefault();
        }

        public IList<Cliente> ClienteTexto(string filtro)
        {
            return _context.TablaCliente.Where(p=>p.documento.Contains(filtro) || p.nombres.Contains(filtro)).ToList();
        }

        public void ClienteInse(Cliente model)
        {

            _context.TablaCliente.Add(model);
            _context.SaveChanges();
        }

        public void ClienteUpda(Cliente model)
        {
            _context.TablaCliente.Update(model);
            _context.SaveChanges();
        }

        public void ClienteDele(Cliente item)
        {
            _context.TablaCliente.Remove(item);
            _context.SaveChanges();
        }

        #endregion

        #region Tabla Producto

        public  IList<Producto> ProductoAll()
        {
            return   _context.TablaProducto.ToList();
        }

        public async void ProductoInse(Producto model)
        {
           _context.TablaProducto.Add(model);
             await    _context.SaveChangesAsync();
        }

      

        public async void ProductoUpda(Producto model)
        {
            _context.TablaProducto.Update(model);
        await  _context.SaveChangesAsync();
        }

        public async void ProductoDele(Producto item)
        {
            _context.TablaProducto.Remove(item);
          await  _context.SaveChangesAsync();
        }

        #endregion

        #region Tabla Serie

        public IList<Serie> SerieAll()
        {
            _context = new DatabaseContext();
            return _context.TablaSerie.ToList();
        }

        public void SerieInse (Serie model)
        {
          
            _context.TablaSerie.Add(model);
            _context.SaveChanges();
        }

        public void SerieUpda(Serie model)
        {
            _context.TablaSerie.Update(model);
            _context.SaveChanges();
        }

        public void SerieDele(Serie item)
        {
            _context.TablaSerie.Remove(item);
            _context.SaveChanges();
        }

        #endregion

        #region Tabla Comprobante

        public IList<Comprobante> ComprobanteAll()
        {
            _context = new DatabaseContext();
            return _context.TablaComprobante.ToList();
        }

        public void ComprobanteInse(Comprobante model)
        {

            _context.TablaComprobante.Add(model);
            _context.SaveChanges();
        }

        public void ComprobanteUpda(Comprobante model)
        {
            _context.TablaComprobante.Update(model);
            _context.SaveChanges();
        }

        public void ComprobanteDele(Comprobante item)
        {
            _context.TablaComprobante.Remove(item);
            _context.SaveChanges();
        }

        public string ComprobanteMax(string serie,string comp)
        {
            try
            {
            var  model=  _context.TablaComprobante.Where(p=> p.serie==serie & p.comp==comp).Max(p => p.nume);
            return (model+1).ToString("00000000");
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return "00000001";
            }
           
        }

        #endregion

        //public void Insert(Serie item)
        //{

        //    var todoItem = _context.TodoItems.FirstOrDefault(x => x.Id == item.Id);


        //    if (todoItem == null)
        //    {

        //    }
        //    else
        //    {
        //       // todoItem[0].descripcion = item.descripcion;
        //       // todoItem.tipocomp = item.tipocomp;
        //       // todoItem.tipoafectacion = item.tipoafectacion;
        //       //todoItem.tipoigv = item.tipoigv;

        //       // _context.TodoItems.Update(todoItem);
        //    }


        //}


    }
}
