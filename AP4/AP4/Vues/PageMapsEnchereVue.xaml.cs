using AP4.Modeles;
using AP4.VueModeles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace AP4.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageMapsEnchereVue : ContentPage
    {
        PageMapsEnchereVueModele vueModele;
        public ObservableCollection<Enchere> ListeEnchere = new ObservableCollection<Enchere>();
        public PageMapsEnchereVue()
        {
            InitializeComponent();
            BindingContext = vueModele = new PageMapsEnchereVueModele();
            Geolocalisation();
        }
        /// <summary>
        /// Permet d'afficher la carte au niveau de la position de l'utilisateur 
        /// </summary>
        public async void Geolocalisation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    Position p = new Position(location.Latitude, location.Longitude);
                    MapSpan mapSpan = MapSpan.FromCenterAndRadius(p, Distance.FromMiles(10));
                    map.MoveToRegion(mapSpan);
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
            } 
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }
        /*
        /// <summary>
        /// Permet de montrer à l'utilisateur la position du magasin de la figurine sur la carte 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SelectionEnchere(object sender, SelectionChangedEventArgs e)
        {
            map.Pins.Clear();
            var enchere = (Enchere)e.CurrentSelection.FirstOrDefault();
            Position positionEnchere = new Position(enchere.LeMagasin.Latitude, enchere.LeMagasin.Longitude);
            Pin pin = new Pin
            {
                Label = enchere.LeMagasin.Nom,
                Address = enchere.LeMagasin.Ville,
                Type = PinType.Place,
                Position = positionEnchere
            };
            map.Pins.Add(pin);
        }*/

        /// <summary>
        /// Permet d'afficher les figurines mise au enchère par le magasin sélectionné
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public void Info(object sender,EventArgs e)
        {
            ListeEnchere.Clear();
            Pin p = (Pin)sender;

            foreach (Enchere uneEnchere in vueModele.MaListeEncheres)
            {
                Position EnchePos = new Position(uneEnchere.LeMagasin.Latitude, uneEnchere.LeMagasin.Longitude);
                if (EnchePos == p.Position)
                {
                    ListeEnchere.Add(uneEnchere);
                }
            }
            Liste.ItemsSource = ListeEnchere;
        }
        private async void SelectionEnchere(object sender, SelectionChangedEventArgs e)
        {
            var enchere = (Enchere)e.CurrentSelection.FirstOrDefault();
            if (enchere.LeTypeEnchere.Id == 1)
            {
                await Navigation.PushAsync(new PageEnchereClassiqueVue(enchere));
            }
            else if (enchere.LeTypeEnchere.Id == 2)
            {
                await Navigation.PushAsync(new PageEnchereInverseVue(enchere));
            }
            else if (enchere.LeTypeEnchere.Id == 3)
            {
                await Navigation.PushAsync(new PageEnchereFlashVue(enchere));
            }
        }
    }
}