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
    public class PageAccueilVueModele : BaseVueModele
    {
        #region Attributs
        private ObservableCollection<Enchere> _maListeEncheresEnCours;
        private ObservableCollection<Enchere> _maListe;

        private readonly Api _apiServices = new Api();


        #endregion

        #region Constructeurs
        public PageAccueilVueModele()
        {
            GetListeEncheres();
        }
        #endregion

        #region Getters/Setters
        //public ICommand CommandBoutonRetour { get; }

        public ObservableCollection<Enchere> MaListeEncheresEnCours
        {
            get
            {
                return _maListeEncheresEnCours;
            }
            set
            {
                SetProperty(ref _maListeEncheresEnCours, value);
            }
        }
        public ObservableCollection<Enchere> MaListe
        {
            get
            {
                return _maListe;
            }
            set
            {
                SetProperty(ref _maListe, value);
            }
        }
        #endregion

        #region Methodes

        public async void GetListeEncheres()
        {
            Enchere.CollClasse.Clear();
            MaListeEncheresEnCours = await _apiServices.GetAllAsync<Enchere>("api/getEncheresEnCours", Enchere.CollClasse);
        }
        #endregion
    }
}
