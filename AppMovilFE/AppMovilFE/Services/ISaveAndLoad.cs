using System;
using System.Collections.Generic;
using System.Text;

namespace AppMovilFE.Services
{
    public interface ISaveAndLoad
    {
        void SaveText(string filename, string text);
        string LoadText(string filename);
    }
}
