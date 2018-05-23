using AppEntity;
using AppMovilFE.Services;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace AppMovilFE.Data
{

    public class DataAcces : IDisposable
    {
        private SQLiteConnection connection;

        public DataAcces()
        {
            var config = DependencyService.Get<ISqlConfi>();
            connection = new SQLiteConnection(config.Platform, System.IO.Path.Combine(config.DirectoryDB, "EFDb7.db3"));
            connection.CreateTable<Producto>();
            connection.CreateTable<Cliente>();
            connection.CreateTable<Comprobante>();



        }

        public void Insert<T>(T model)
        {
            connection.Insert(model);
        }

        public void Update<T>(T model)
        {
            connection.Update(model);
        }

        public void Delete<T>(T model)
        {
            connection.Delete(model);
        }

        public List<T> GetList<T>(bool WithChildren) where T : class
        {
            if (WithChildren)
            {
                return connection.GetAllWithChildren<T>().ToList();
            }
            else
            {
                return connection.Table<T>().ToList();
            }
        }

        public T First<T>(bool WithChildren) where T : class
        {
            if (WithChildren)
            {
                return connection.GetAllWithChildren<T>().FirstOrDefault();
                // connection.Query<T>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
                //connection.ExecuteScalar<int>("SELECT Count(*) FROM Person");
            }
            else
            {
                return connection.Table<T>().FirstOrDefault();
            }
        }

        public T Find<T>(int pk, bool WithChildren) where T : class
        {
            if (WithChildren)
            {
                return connection.GetAllWithChildren<T>().FirstOrDefault(m => m.GetHashCode() == pk);
            }
            else
            {
                return connection.Table<T>().FirstOrDefault(m => m.GetHashCode() == pk);
            }

        }

        //estructuras especiales


        //tabla comprobante

        public string ComprobanteMax(string serie, string comp)
        {
            
            try
            {
                var model = connection.Table<Comprobante>().Where(p => p.serie == serie & p.comp == comp).Max(p => p.nume);
                return (model + 1).ToString("00000000");
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return "00000001";
            }

        }

        // tabla producto

        public Producto ProductoCodi(string codi)
        {
            return connection.Table<Producto>().Where(p => p.prod_codi == codi).FirstOrDefault();
        }

        public IList<Producto> ProductoTexto(string filtro)
        {
            return connection.Table<Producto>().Where(p => p.prod_codi.Contains(filtro) || p.prod_descr.Contains(filtro)).ToList();
        }



        //tabla cliente

        public Cliente ClienteDocu(string tipodoc, string docu)
        {
            return connection.Table<Cliente>().Where(p => p.tipodocu == tipodoc && p.documento == docu).FirstOrDefault();
        }

        public IList<Cliente> ClienteTexto(string filtro)
        {
            return connection.Table<Cliente>().Where(p => p.documento.Contains(filtro) || p.nombres.Contains(filtro)).ToList();
        }

        // te gusta el tsql

        //public List<T> FinProdCate<T>(string cate_codi) where T : class
        //{
        //    return connection.Query<T>("SELECT * FROM [Producto] WHERE [cate_codi] = " + cate_codi);
        //}

        public void Dispose()
        {
            //  null;
        }
    }

}
