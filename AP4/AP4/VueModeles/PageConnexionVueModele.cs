using AP4.Modeles;
using AP4.Services;
using AP4.Vues;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AP4.VueModeles
{
    public class PageConnexionVueModele : BaseVueModele
    {
        #region Attributs
        //private ObservableCollection<Produit> _maListeProduits;
        private readonly Api _apiServices = new Api();

        protected Page page;
        private string _emailEntry;
        private string _passwordEntry;
        #endregion

        #region Constructeurs
        public PageConnexionVueModele(Page page)
        {
            CommandBoutonRetour = new Command(ActionCommandBoutonRetour);
            CommandBoutonConnexion = new Command(OnSubmit);
        }
        #endregion

        #region Getters/Setters
        public string EmailEntry
        {
            get
            {
                return _emailEntry;
            }
            set
            {
                SetProperty(ref _emailEntry, value);
            }
        }

        public string PasswordEntry
        {
            get
            {
                return _passwordEntry;
            }
            set
            {
                SetProperty(ref _passwordEntry, value);
            }
        }
        public ICommand CommandBoutonRetour { get; }
        public ICommand CommandBoutonConnexion { get; private set; }

        //public ObservableCollection<Produit> MaListeProduits { get => _maListeProduits; set => _maListeProduits = value; }

        #endregion

        #region Methodes
        public void ActionCommandBoutonRetour()
        {
            Application.Current.MainPage = new PageIndexVue();
        }
        public async void OnSubmit()
        {
            /*if ()
            {
                Application.Current.MainPage = new PageAccueilVue();
                await page.DisplayAlert("Bravo", "Vous êtes connecté!", "ok");
            }
            else
            {
                await page.DisplayAlert("Erreur", "Votre mot de passe ou votre email n'est pas bon !", "ok");
            }*/
        }
        /*public async void GetListeProduits()
        {
            MaListeProduits = await _apiServices.GetAllAsync<Produit>
                   ("api/getProduits", Produit.CollClasse);
        }*/
        #endregion
    }
}
