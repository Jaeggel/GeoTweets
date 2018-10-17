using Npgsql;
using ProyectoGISTweets.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGISTweets.AccesoDatos
{
    public class AccDatos
    {
        private static NpgsqlConnection conn = null;
        string Connstring = null;
        public AccDatos()
        {
            Connstring = "Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=tweters;";
            ConnectDB();
        }
        public Boolean ConnectDB()
        {
            try
            {
                conn = new NpgsqlConnection(Connstring);
                conn.Open();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public Boolean IngresoTweets(Tweets tweets)
        {
            try
            { 
                if (tweets.Text.IndexOf("'") >= 0)
                {
                    tweets.Text = tweets.Text.Replace(@"'", string.Empty);
                }
                if (tweets.User.IndexOf("'") >= 0)
                {
                    tweets.User = tweets.User.Replace(@"'", string.Empty);
                }
                if (tweets.Location != null)
                {
                    if (tweets.Location.IndexOf("'") >= 0)
                    {
                        tweets.Location = tweets.Location.Replace(@"'", string.Empty);
                    }
                }
                string querycoord = "ST_GeomFromText('POINT(" + tweets.Latitud + " " + tweets.Longitud + ")'";
                string query = "INSERT INTO public.tendencias(locacion, geo, usuario, fecha, text, id, screen_name)VALUES ('" + tweets.Location + "'," + querycoord.Replace(",", ".") + ",3857), '" + tweets.User + "', '" + tweets.Time + "', '" + tweets.Text + "'," + tweets.Id + ", '" + tweets.ScreenName + "');";
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public Boolean IngresoTweetsLista(List<Tweets> lst)
        {           
            try
            {
                foreach (var tweets in lst)
                {
                    //if(!VerifLocation(tweets.Id))
                    {
                        string querycoord = "ST_GeomFromText('POINT(" + tweets.Latitud + " " + tweets.Longitud + ")'";
                        if (tweets.Text.IndexOf("'") >= 0)
                        {
                            tweets.Text = tweets.Text.Replace(@"'", string.Empty);
                        }
                        if (tweets.User.IndexOf("'") >= 0)
                        {
                            tweets.User = tweets.User.Replace(@"'", string.Empty);
                        }
                        if (tweets.Location != null)
                        {
                            if (tweets.Location.IndexOf("'") >= 0)
                            {
                                tweets.Location = tweets.Location.Replace(@"'", string.Empty);
                            }
                        }
                        string query = "INSERT INTO public.tendencias(locacion, geo, usuario, fecha, text, id, screen_name)VALUES ('" + tweets.Location + "'," + querycoord.Replace(",", ".") + ",3857), '" + tweets.User + "', '" + tweets.Time + "','" + tweets.Text + "'," + tweets.Id + ", '" + tweets.ScreenName + "');";
                        NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                        cmd.ExecuteNonQuery();
                    }
                }
                conn.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public List<Tweets> ObtenerListaTweets()
        {
            List<Tweets> lst = new List<Tweets>();
            try
            {
                NpgsqlCommand command = new NpgsqlCommand("SELECT locacion,ST_X(GEO), ST_Y(GEO),USUARIO,FECHA,TEXT,ID,SCREEN_NAME FROM tendencias;", conn);
                NpgsqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Tweets est = new Tweets
                    {
                        Location = dr[0].ToString().Trim(),
                        Latitud= float.Parse(dr[1].ToString().Trim().Replace(",","."), CultureInfo.InvariantCulture),
                        Longitud = float.Parse(dr[2].ToString().Trim().Replace(",", "."), CultureInfo.InvariantCulture),
                        User= dr[3].ToString().Trim(),
                        Time=dr[4].ToString().Trim(),
                        Text= dr[5].ToString().Trim(),
                        Id= Int64.Parse(dr[6].ToString().Trim()),
                        ScreenName= dr[7].ToString().Trim()
                    };
                    lst.Add(est);
                }
                conn.Close();
            }
            catch (Exception e)
            {
                lst = null;
            }
            return lst;
        }
        public Boolean VerifLocation(Int64 id)
        {
            var lst = ObtenerListaTweets();
            var item = lst.Find(x => x.Id == id);
            ConnectDB();
            if(item!=null)
            {
                return true;
            }
            return false;
        }
    }
}
