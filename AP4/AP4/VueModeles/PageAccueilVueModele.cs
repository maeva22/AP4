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
        private ObservableCollection<Enchere> _maListeEncheresEnCoursClassique;
        private ObservableCollection<Enchere> _maListeEncheresEnCoursInverse;
        private ObservableCollection<Enchere> _maListeEncheresEnCoursFlash;

        private bool _visibleEnchereEnCoursClassique = true;
        private bool _visibleEnchereEnCoursInverse = true;
        private bool _visibleEnchereEnCoursFlash = true;

        private readonly Api _apiServices = new Api();


        #endregion

        #region Constructeurs
        public PageAccueilVueModele()
        {
            //GetListeEncheres();
            GetListeEncheresEnCoursClassiques(1);
            GetListeEncheresEnCoursInversees(2);
            GetListeEncheresEnCoursFlashs(3);
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
        public ObservableCollection<Enchere> MaListeEncheresEnCoursClassique
        {
            get
            {
                return _maListeEncheresEnCoursClassique;
            }
            set
            {
                SetProperty(ref _maListeEncheresEnCoursClassique, value);
            }
        }
        public ObservableCollection<Enchere> MaListeEncheresEnCoursInverse
        {
            get
            {
                return _maListeEncheresEnCoursInverse;
            }
            set
            {
                SetProperty(ref _maListeEncheresEnCoursInverse, value);
            }
        }
        public ObservableCollection<Enchere> MaListeEncheresEnCoursFlash
        {
            get
            {
                return _maListeEncheresEnCoursFlash;
            }
            set
            {
                SetProperty(ref _maListeEncheresEnCoursFlash, value);
            }
        }

        public bool VisibleEnchereEnCoursClassique
        {
            get { return _visibleEnchereEnCoursClassique; }
            set { SetProperty(ref _visibleEnchereEnCoursClassique, value); }
        }

        public bool VisibleEnchereEnCoursInverse
        {
            get { return _visibleEnchereEnCoursInverse; }
            set { SetProperty(ref _visibleEnchereEnCoursInverse, value); }
        }
        public bool VisibleEnchereEnCoursFlash
        {
            get { return _visibleEnchereEnCoursFlash; }
            set { SetProperty(ref _visibleEnchereEnCoursFlash, value); }
        }
        #endregion

        #region Methodes

        /*public async void GetListeEncheres()
        {
            Enchere.CollClasse.Clear();
            MaListeEncheresEnCours = await _apiServices.GetAllAsync<Enchere>("api/getEncheresEnCours", Enchere.CollClasse);
        }*/
        public async void GetListeEncheresEnCoursClassiques(int idEnchereEnCoursClassique)
        {
            MaListeEncheresEnCoursClassique = await _apiServices.GetAllAsyncID<Enchere>("api/getEncheresEnCours", Enchere.CollClasse, "IdTypeEnchere", idEnchereEnCoursClassique);
            Enchere.CollClasse.Clear();
        }
        public async void GetListeEncheresEnCoursInversees(int idEnchereEnCoursInversees)
        {
            MaListeEncheresEnCoursInverse = await _apiServices.GetAllAsyncID<Enchere>("api/getEncheresEnCours", Enchere.CollClasse, "IdTypeEnchere", idEnchereEnCoursInversees);
            Enchere.CollClasse.Clear();
        }
        public async void GetListeEncheresEnCoursFlashs(int idEnchereEnCoursFlashs)
        {
            MaListeEncheresEnCoursFlash = await _apiServices.GetAllAsyncID<Enchere>("api/getEncheresEnCours", Enchere.CollClasse, "IdTypeEnchere", idEnchereEnCoursFlashs);
            Enchere.CollClasse.Clear();
        }
        #endregion
    }
}
