using AP4.Vues;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AP4.VueModeles
{
    public class PageIndexVueModele : BaseVueModele
    {
        #region Attributs
        #endregion

        #region Constructeurs
        public PageIndexVueModele()
        {
            CommandBoutonInscription = new Command(ActionCommandBoutonInscription);

            CommandBoutonConnexion = new Command(ActionCommandBoutonConnexion);

            TapCommandAccueil = new Command(ActionTapCommandAccueil);
        }
        #endregion

        #region Getters/Setters
        public ICommand CommandBoutonInscription { get; }
        public ICommand CommandBoutonConnexion { get; }
        public ICommand TapCommandAccueil { get; }
        #endregion

        #region Methodes
        /// <summary>
        /// permet d'accéder à la page d'inscription
        /// </summary>
        public void ActionCommandBoutonInscription()
        {
            Application.Current.MainPage = new PageInscriptionVue();
        }
        /// <summary>
        /// permet d'accéder à la page de connexion
        /// </summary>
        public void ActionCommandBoutonConnexion()
        {
            Application.Current.MainPage = new PageConnexionVue();
        }
        /// <summary>
        /// permet d'accéder à la page des enchères en cours sans se connecter
        /// </summary>
        public void ActionTapCommandAccueil()
        {
            Application.Current.MainPage = new AppShell();
        }
        #endregion
    }
}
