using Newtonsoft.Json;
using PM2E2GRUPO6.Controlador;
using PM2E2GRUPO6.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E2GRUPO6.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listado_Sitios : ContentPage
    {
        public Listado_Sitios()
        {
            InitializeComponent();
        }

        public async void Mostrar()
        {
            List<Sitios_ID> listaSitios = new List<Sitios_ID>();
            listaSitios = await ControladorSitios.GetSitios();


            listas.ItemsSource = listaSitios;
        }

      

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Mostrar();
        }

        private async void VerDetalles(object sender, EventArgs e)
        {
             SwipeItem item = sender as SwipeItem;
            Sitios_ID model = item.BindingContext as Sitios_ID;
            await Navigation.PushAsync(new Modificar(model));
        }

        private void listas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            listas.SelectedItem = null;

        }

        private void SwipeItem_Invoked(object sender, EventArgs e)
        {
        
            SwipeItem item = sender as SwipeItem;
            Sitios_ID model = item.BindingContext as Sitios_ID;
            Eliminar(model.id);
            //await DisplayAlert("Sitios", model.descripcion  , "ok");
            // await Navigation.PushAsync(new DetallesFirmas(model));
        }

        private async void SwipeItem_Invoked_1(object sender, EventArgs e)
        {
            SwipeItem item = sender as SwipeItem;
            Sitios_ID model = item.BindingContext as Sitios_ID;
            //await DisplayAlert("Sitios", model.descripcion  , "ok");

            double lat = Convert.ToDouble(model.latitud);
            double lon = Convert.ToDouble(model.longitud);

            await Navigation.PushAsync(new FourSquareVista(lat,lon));
        }

        public async void Eliminar(int eleminar)
        {

            delete_id delete = new delete_id
            {
                id = eleminar
            };


            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    Uri RequestUri = new Uri(DireccionesServidor.DeleteSitios);
                    var json = JsonConvert.SerializeObject(delete);
                    var contentJSON = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await cliente.PostAsync(RequestUri, contentJSON);

                    if (response.IsSuccessStatusCode)
                    {
                        Mostrar();
                        Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                    }
                }
            }
            catch (Exception)
            {

            }



        }

        private async void SwipeItem_Invoked_2(object sender, EventArgs e)
        {
            SwipeItem item = sender as SwipeItem;
            Sitios_ID model = item.BindingContext as Sitios_ID;

            Double lat = Convert.ToDouble(model.latitud);
            Double longi = Convert.ToDouble(model.longitud);

            var location = new Location(lat, longi);
            var options = new MapLaunchOptions { NavigationMode = NavigationMode.Driving };
            await Map.OpenAsync(location, options);
        }
    }
}