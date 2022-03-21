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
        public void ActionCommandBoutonInscription()
        {
            Application.Current.MainPage = new PageInscriptionVue();
        }

        public void ActionCommandBoutonConnexion()
        {
            Application.Current.MainPage = new PageConnexionVue();
        }

        public void ActionTapCommandAccueil()
        {
            Application.Current.MainPage = new AppShell();
        }
        #endregion
    }
}
