using AppEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMovilFE.Services
{
    interface IEntityFrameworkService
    {
        IList<Serie> SerieAll();
        void SerieInse(Serie item);
        void SerieUpda(Serie item);
        void SerieDele(Serie item);
    }
}
