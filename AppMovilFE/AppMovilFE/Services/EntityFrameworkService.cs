using AppEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppMovilFE.Services
{
    class EntityFrameworkService: IEntityFrameworkService
    {
        private DatabaseContext _context;

        public EntityFrameworkService()
        {
            _context = new DatabaseContext();
        }

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
            var  model=  _context.TablaComprobante.Where(p=> p.serie==serie & p.comp==comp).Max();
            return double.Parse(model.nume).ToString("00000000");
            }
            catch (Exception)
            {
              
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
