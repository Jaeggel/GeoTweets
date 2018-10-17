using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ProyectoGISTweets.Models
{
    public class DataTemp
    {
        public static List<Tweets> TweetsData = new List<Tweets> {
            new Tweets {
                Location="Austin, TX",
                User="Foxy's Cabaret ATX",
                Latitud=30.424563f,
                Longitud=-97.697798f,
                Time="Wed Jul 18 00:15:54 +0000 2018",
                Text="#Foxys #PajamaJam w/ @djkoma &amp; @mixxula this weekend!  Call and make your reservations today! Join all the Foxy's hotties live til 5! See you soon!\n\n\u30fb\u30fb\u30fb\n#\ud83e\udd8a #\ud83d\udc6f\u200d\u2640\ufe0f\u2026 https://t.co/9OwPczsOfW",
                Id=735602753574047744,
                ScreenName="FoxysCabare"
            }
        };
    }
}