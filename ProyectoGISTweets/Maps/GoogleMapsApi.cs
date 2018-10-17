using ProyectoGISTweets.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;


namespace ProyectoGISTweets.Maps
{
    public class GoogleMapsApi
    {
        private static string ApiKey = ConfigurationManager.AppSettings["GoogleMapsApiKey"];
        ///// <summary>
        ///// Método para obtener el objeto proveniente del archivo JSON de Google Maps.
        ///// </summary>
        ///// <param name="lab"></param>
        ///// <returns></returns>
        //public Rootobject GetRootObject(Laboratorios lab)
        //{
        //    Rootobject mapdata=new Rootobject();
        //    try
        //    {
        //        string json = string.Empty;
        //        int cont = 0;
        //        var aux = "";
        //        if (lab.Direccion=="")
        //        {
        //            cont = 1;
        //        }
        //        else
        //        {
        //            aux = AddressFormat(lab.Ciudad, lab.Direccion);
        //        }
        //        do
        //        {
        //            if (cont == 1)
        //            {
        //                aux = AddressFormat(lab.Ciudad, lab.Nombre);
        //            }
        //            else if(cont>1)
        //            {
        //                aux = lab.Ciudad;
        //            }
        //            using (WebClient wc = new WebClient())
        //            {
        //                json = @wc.DownloadString("https://maps.googleapis.com/maps/api/geocode/json?address=" + aux + "&key=" + ApiKey);
        //            }
        //            mapdata = JsonConvert.DeserializeObject<Rootobject>(json);
        //            cont++;
        //        } while (mapdata.status == "ZERO_RESULTS");
        //        GetLocationInfo(mapdata,lab);
        //    }
        //    catch(Exception)
        //    {
        //        mapdata = null;
        //    }
        //    return mapdata;
        //}
        ///// <summary>
        ///// Método para obtener los parámetros básicos de ubicación del laboratorio
        ///// </summary>
        ///// <param name="mapdata"></param>
        ///// <param name="info"></param>
        ///// <returns></returns>
        //public Laboratorios GetLocationInfo(Rootobject mapdata,Laboratorios info)
        //{
        //    try
        //    {                
        //        var rst = mapdata.results;
        //        foreach (var item in rst)
        //        {
        //            foreach (var add in item.address_components)
        //            {
        //                foreach (var types in add.types)
        //                {
        //                    //Obtener Ciudad del Json de Google
        //                    //if (add.types[0] == "locality" && add.types[1] == "political")
        //                    //{
        //                    //    info.Ciudad = add.long_name;
        //                    //}
        //                    if (add.types[0] == "administrative_area_level_1" && add.types[1] == "political")
        //                    {
        //                        info.Provincia = add.long_name;
        //                    }
        //                }
        //            }
        //            info.Formato_Direccion = item.formatted_address;
        //            info.Longitud = item.geometry.location.lng;
        //            info.Latitud = item.geometry.location.lat;
        //        }
        //    }
        //    catch(Exception)
        //    {
        //        info = null;
        //    }
        //    return info;
        //}
        /// <summary>
        /// Método para dar formato a la cadena que será insertada en la URL para la obtención del JSON de Google Maps
        /// </summary>
        /// <param name="cadena1"></param>
        /// <param name="cadena2"></param>
        /// <returns></returns>
        public string AddressFormat(string cadena1,string cadena2)
        {
            if(cadena2=="")
            {
                return cadena1;
            }
            else
            {
                return cadena1.Trim().Replace(" ", "+") + "+" + cadena2.Trim().Replace(" ", "+");
            }
        }
        private static IEnumerable<JToken> AllChildren(JToken json)
        {
            foreach (var c in json.Children())
            {
                yield return c;
                foreach (var cc in AllChildren(c))
                {
                    yield return cc;
                }
            }
        }
    }
}