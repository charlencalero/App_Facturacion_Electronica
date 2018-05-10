using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using AppEntity;

namespace AppMovilFE.Data
{
    class ApiAcces
    {
        public async Task<String> Service(string url)
        {
            string result;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Constantes.RestUrl);

                    var response = await client.GetAsync(url);

                    result = response.Content.ReadAsStringAsync().Result;
                }
            }
            catch (Exception)
            {

                return null;
            }


            try
            {
                JsonConvert.DeserializeObject(result);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public async Task<String> ServicePost(string url, object ks)
        {
            string result;
            try
            {

                var jsonreq = JsonConvert.SerializeObject(ks);
                var conten = new StringContent(jsonreq, Encoding.UTF8, "text/json");

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Constantes.RestUrl);
                    var response = await client.PostAsync(url, conten);
                    result = response.Content.ReadAsStringAsync().Result;
                }



            }
            catch (Exception)
            {
                return null;
            }

            try
            {
                JsonConvert.DeserializeObject(result);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }



        public async Task<Respuesta> EnviarComprobante(Comprobante Comp)
        {
            string url = string.Format("/api/comprobante");
            string result = await ServicePost(url, Comp);

            return JsonConvert.DeserializeObject<Respuesta>(result);

        }

        //public async Task<Respuesta> Imprimir(string CODSALON, string NROMESA)
        //{
        //    string url = string.Format(Constantes.CarpUrl + "/pedido_impresion?codsalon={0}&nromesa={1}", CODSALON, NROMESA);
        //    string result = await Service(url);

        //    return JsonConvert.DeserializeObject<Respuesta>(result);

        //}
        //public async Task<Respuesta> Compuesta(List<Juntar> Compu)
        //{
        //    string url = string.Format("/api/Compuesta");
        //    string result = await ServicePost(url, Compu);

        //    return JsonConvert.DeserializeObject<Respuesta>(result);

        //}




    }
}
