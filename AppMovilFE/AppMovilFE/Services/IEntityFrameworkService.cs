using AppEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMovilFE.Services
{
    interface IEntityFrameworkService
    {
        IList<Serie> GetAll();
        void Insert(Serie item);
        void Remove(Serie item);
    }
}
