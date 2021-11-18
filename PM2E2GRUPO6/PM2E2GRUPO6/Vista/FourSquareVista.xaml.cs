using PM2E2GRUPO6.Controlador;
using PM2E2GRUPO6.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E2GRUPO6.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FourSquareVista : ContentPage
    {
        double latitud, longitud;

        public FourSquareVista(double lat, double lon)
        {
            InitializeComponent();
            latitud = lat;
            longitud = lon;
            //cargarInformacion();
        }

        //Cargar toda la informacion por la lonitud y latitud del celular y por rango de distancias
        public async void cargarTodaInformacionRango(double lat_static, double lon_static)
        {

            List<Modelo.FourSquare.Venue> sitioscercas = new List<Modelo.FourSquare.Venue>();

            sitioscercas = await ControladorSitios.GetListSites(lat_static, lon_static);

            int rango_distancia = Convert.ToInt32(txtMetros.Text);


            List<Modelo.MDistancia_Rango> sitios_distancia = new List<Modelo.MDistancia_Rango>();

            for (var i = 0; i < sitioscercas.Count; i++)
            {



                if ((sitioscercas[i].location.distance <= rango_distancia) && (sitioscercas[i].location.distance >= 0))
                {
 
                    int distance = sitioscercas[i].location.distance;
                    string name = sitioscercas[i].name;
                    string lat = sitioscercas[i].location.lat.ToString();
                    string lng = sitioscercas[i].location.lng.ToString();
                    string addres = sitioscercas[i].location.address;
                    string city = sitioscercas[i].location.city;
                    string state = sitioscercas[i].location.state;

                    MDistancia_Rango siti = new MDistancia_Rango
                    {
                        distancia = distance,
                        nombre = name,
                        latitud = lat,
                        longitud = lng,
                        direccion = addres,
                        ciudad = city,
                        estado = state
                    };

                    sitios_distancia.Add(siti);
                    //sitios_distancia.Add(new MDistancia_Rango { distancia = distance, nombre = name, latitud = lat, longitud = lng, direccion = addres, ciudad=city, estado=state });

                }


                //Console.WriteLine(sitios_distancia[0].nombre);

            }

            lstFourSquare.ItemsSource = sitios_distancia;

        }


        //esta funcion carga Toda la informacion
        public async void cargarTodaLainformacion(double lat_static, double lon_static)
        {


            List<Modelo.FourSquare.Venue> sitioscercas = new List<Modelo.FourSquare.Venue>();

            sitioscercas = await ControladorSitios.GetListSites(lat_static, lon_static);

            List<Modelo.MDistancia_Rango> sitios_distancia = new List<Modelo.MDistancia_Rango>();

            for (var i = 0; i < sitioscercas.Count; i++)
            {

                int distance = sitioscercas[i].location.distance;
                string name = sitioscercas[i].name;
                string lat = sitioscercas[i].location.lat.ToString();
                string lng = sitioscercas[i].location.lng.ToString();
                string addres = sitioscercas[i].location.address;
                string city = sitioscercas[i].location.city;
                string state = sitioscercas[i].location.state;

                MDistancia_Rango siti = new MDistancia_Rango
                {
                    distancia = distance,
                    nombre = name,
                    latitud = lat,
                    longitud = lng,
                    direccion = addres,
                    ciudad = city,
                    estado = state
                };

                sitios_distancia.Add(siti);
                //sitios_distancia.Add(new MDistancia_Rango { distancia = distance, nombre = name, latitud = lat, longitud = lng, direccion = addres, ciudad=city, estado=state });


            }

            lstFourSquare.ItemsSource = sitios_distancia;

        }

        // carga los datos de una sola ubicacion
        public async void cargarInformacionStatica()
        {
            //informacion de chirstian
            double lat_static = 15.574558, lon_static = -87.935560;

            List<Modelo.FourSquare.Venue> sitioscercas = new List<Modelo.FourSquare.Venue>();

            sitioscercas = await ControladorSitios.GetListSites(lat_static, lon_static);

            int rango_distancia = Convert.ToInt32(txtMetros.Text);


            List<Modelo.MDistancia_Rango> sitios_distancia = new List<Modelo.MDistancia_Rango>();

            for (var i = 0; i < sitioscercas.Count; i++)
            {

                //Console.WriteLine(sitioscercas[i].location.distance);

                //int tomarDistancia = sitioscercas[i].location.distance;

                if ((sitioscercas[i].location.distance <= rango_distancia) && (sitioscercas[i].location.distance >= 0))
                {
                    Console.WriteLine(sitioscercas[i].location.distance);

                    int distance = sitioscercas[i].location.distance;
                    string name = sitioscercas[i].name;
                    string lat = sitioscercas[i].location.lat.ToString();
                    string lng = sitioscercas[i].location.lng.ToString();
                    string addres = sitioscercas[i].location.address;
                    string city = sitioscercas[i].location.city;
                    string state = sitioscercas[i].location.state;

                    MDistancia_Rango siti = new MDistancia_Rango
                    {
                        distancia = distance,
                        nombre = name,
                        latitud = lat,
                        longitud = lng,
                        direccion = addres,
                        ciudad = city,
                        estado = state
                    };

                    sitios_distancia.Add(siti);
                    //sitios_distancia.Add(new MDistancia_Rango { distancia = distance, nombre = name, latitud = lat, longitud = lng, direccion = addres, ciudad=city, estado=state });

                }


                //Console.WriteLine(sitios_distancia[0].nombre);

            }

            lstFourSquare.ItemsSource = sitios_distancia;

        }

        private void lstFourSquare_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            lstFourSquare.SelectedItem = null;
        }

        private async void VerDetalles(object sender, EventArgs e)
        {
            //obtenemos todo los datos del listview cuando le damos en ver mas
            SwipeItem item = sender as SwipeItem;
            MDistancia_Rango model = item.BindingContext as MDistancia_Rango;

            Double lat = Convert.ToDouble(model.latitud);
            Double longi = Convert.ToDouble(model.longitud);

            string a = "Distancia: "+model.distancia.ToString()+" \n Nombre: "+model.nombre +
                "\n Latitud: " + lat.ToString() + "\n Longitud: " + longi.ToString()+
                "\n Direccion: "+model.direccion + "\n Ciudad: " + model.ciudad + "\n Estado: "+model.estado;

            await DisplayAlert("Datos", a, "ok");
        }

        private async void SwipeItem_Invoked(object sender, EventArgs e)
        {
            //obtenemos todo los datos del listview cuano ver mapa 
            SwipeItem item = sender as SwipeItem;
            MDistancia_Rango model = item.BindingContext as MDistancia_Rango;

            Double lat = Convert.ToDouble(model.latitud);
            Double longi = Convert.ToDouble(model.longitud);

            var location = new Location(lat, longi);
            var options = new MapLaunchOptions { NavigationMode = NavigationMode.Driving };
            await Map.OpenAsync(location, options);
        }

        private void txtMetros_TextChanged(object sender, TextChangedEventArgs e)
        {
            // este codigo hace que no imprima en un punto . o un guien - en el entry
            string strName = txtMetros.Text;

            if (strName.Contains(".") || strName.Contains("-"))
            {
                strName = strName.Replace(".", "").Replace("-", "");
                txtMetros.Text = strName;
            }
        }

        private async void btnmetros_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtMetros.Text) == true)
            {
                await DisplayAlert("Mensaje", "El entry esta vacio", "Ok");
            }
            else
            {
                cargarTodaInformacionRango(latitud,longitud);
            }
         }

        private void btnStatics_Clicked(object sender, EventArgs e)
        {
            cargarTodaLainformacion(latitud, longitud);
        }

        private async void btnstatica_Clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtMetros.Text) == true)
            {
                await DisplayAlert("Mensaje", "El entry esta vacio", "Ok");
            }
            else
            {
                cargarInformacionStatica();
            }
        }

        protected override void OnAppearing()
        {

            base.OnAppearing();

        }
    }
}