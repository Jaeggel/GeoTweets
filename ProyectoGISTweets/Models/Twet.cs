using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoGISTweets.Models
{
    public class Twet
    {
        public string LOCATION { get; set; }
        public string GEO { get; set; }
        public string USER { get; set; }
        public string TIME { get; set; }
        public string TEXT { get; set; }
        public string POLIGONO { get; set; }
        public Int64 id { get; set; }
        public string SCREEN_NAME { get; set; }
    }
}