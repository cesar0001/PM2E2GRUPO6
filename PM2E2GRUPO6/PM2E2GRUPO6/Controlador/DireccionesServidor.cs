using System;
using System.Collections.Generic;
using System.Text;

namespace PM2E2GRUPO6.Controlador
{
    
    public class DireccionesServidor
    {

        public static string ip_server = "167.99.158.191";

        //GuardarSitios
        public static string saveSitios = "http://" + ip_server + "/examenxamarin/Usuarios/crear_usuarios.php";

        //TenerSitios
        public static string GetSitios = "http://" + ip_server + "/examenxamarin/Usuarios/obtener_usuario.php";

        //TenerSitios
        public static string DeleteSitios = "http://" + ip_server + "/examenxamarin/Usuarios/eliminar_usuario.php";

        //UpdateSitios
        public static string UpdateSitios = "http://" + ip_server + "/examenxamarin/Usuarios/actualizar_usuario.php";

        public const string client_id = "VJMKF4LTPUGX5LYESDTNFJ51TGFYO5GPHDHCN3UBR0PGKRHE";
        public const string client_secret = "PRXJ0FEJY3HBHCQBCIMBX0EJWRACCOXSRWWKYYU1SKPBXYZV";
        public const string EndPointFoursquare = "https://api.foursquare.com/v2/venues/search?ll={0},{1}&client_id={2}&client_secret={3}&v={4}";

        public static String getUrl(double latitud, double longitud)
        {
            var url = String.Format(EndPointFoursquare, latitud, longitud,
                 client_id, client_secret, DateTime.Now.ToString("yyyyMMdd"));

            return url;
        }

    }
}
