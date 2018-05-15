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

        public IList<Serie> GetAll()
        {
            _context = new DatabaseContext();
            return _context.TodoItems.ToList();
        }

        public void Insert(Serie item)
        {
            var todoItem = _context.TodoItems.Find(item.descripcion);

            if (todoItem == null)
            {
                _context.TodoItems.Add(item);
            }
            else
            {
                todoItem.descripcion = item.descripcion;
                todoItem.tipocomp = item.tipocomp;
                todoItem.tipoafectacion = item.tipoafectacion;
                todoItem.tipoigv = item.tipoigv;

                _context.TodoItems.Update(todoItem);
            }

            _context.SaveChanges();
        }

        public void Remove(Serie item)
        {
            _context.TodoItems.Remove(item);
            _context.SaveChanges();
        }
    }
}
