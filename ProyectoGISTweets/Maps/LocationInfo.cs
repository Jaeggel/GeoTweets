using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoGISTweets.Maps
{
    /// <summary>
    /// Parámetros básicos de ubicación del laboratorio
    /// </summary>
    public class LocationInfo
    {
        public string Provincia { get; set; }
        public string Ciudad { get; set; }
        public string Formato_Direccion { get; set; }
        public float Latitud { get; set; }
        public float Longitud{ get; set; }
        public string Laboratorio{ get; set; }
    }
}