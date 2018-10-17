using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoGISTweets.Models
{
    public class Tweets
    {
        public string Location { get; set; }

        public float Latitud{ get; set; }

        public float Longitud{ get; set; }

        public string User { get; set; }

        public string Time{ get; set; }

        public string Text{ get; set; }

        public Int64 Id { get; set; }

        public string ScreenName{ get; set; }
    }
}