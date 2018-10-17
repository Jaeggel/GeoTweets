using Newtonsoft.Json;
using ProyectoGISTweets.AccesoDatos;
using ProyectoGISTweets.Maps;
using ProyectoGISTweets.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace ProyectoGISTweets.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Ingreso()
        {
            return View();
        }
        public ActionResult IngresoJson()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ingreso(Tweets tweets)
        {
            AccDatos db = new AccDatos();
            if (!db.VerifLocation(tweets.Id))
            {
                if (db.IngresoTweets(tweets))
                {
                    ViewBag.RegisterVerif = "Los datos del tweet han sido ingresados correctamente...";
                }
            }
            ViewBag.RegisterVerifError = "Ya existe una ubicación con ese ID...";
            return View();
        }
        [HttpPost]
        public ActionResult CargaJson(HttpPostedFileBase file)
        {
            List<Twet> lst = new List<Twet>();
            List<Tweets> lstBD = new List<Tweets>();
            if (file != null && file.ContentLength > 0)
                try
                {
                    string result = new StreamReader(file.InputStream).ReadToEnd();
                    lst = JsonConvert.DeserializeObject<List<Twet>>(result);
                    foreach (var item in lst)
                    {
                        String pattern = @"\[([^\[\]]+)\]";
                        List<string> aux = new List<string>();
                        foreach (Match m in Regex.Matches(item.GEO, pattern))
                        {
                            aux.Add(m.Groups[1].Value.ToString());
                        }
                        String[] strCoord = aux[0].Split(',');
                        float LatitudJson = float.Parse(strCoord[1], CultureInfo.InvariantCulture);
                        float LongitudJson = float.Parse(strCoord[0], CultureInfo.InvariantCulture);
                        Tweets obj = new Tweets
                        {
                            Location = item.LOCATION,
                            Id=item.id,
                            ScreenName=item.SCREEN_NAME,
                            Text=item.TEXT,
                            Time=item.TIME,
                            User=item.USER,
                            Latitud=LatitudJson,
                            Longitud=LongitudJson
                        };
                        lstBD.Add(obj);
                    }
                    AccDatos db = new AccDatos();
                    if (db.IngresoTweetsLista(lstBD))
                    {
                        ViewBag.Message = "Archivo Cargado Correctamente...";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.MessageError = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.MessageError = "No se ha especificado una dirección.";
            }
            return View("IngresoJson");
        }
        public ActionResult About()
        {
            return View();
        }
        public JsonResult SetMap()
        {
            AccDatos db = new AccDatos();
            return Json(db.ObtenerListaTweets(), JsonRequestBehavior.AllowGet);
        }
    }
}