using AP4.Modeles;
using AP4.Services;
using AP4.Vues;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AP4.VueModeles.PageAccueilEnchereEnCoursVueModele
{
    public class PageAccueilEnchereEnCoursClassiquesVueModele : BaseVueModele
    {
        #region Attributs
        private ObservableCollection<Enchere> _maListeEncheresEnCoursClassique;

        private readonly Api _apiServices = new Api();
        #endregion

        #region Constructeurs
        public PageAccueilEnchereEnCoursClassiquesVueModele()
        {
            GetListeEncheresEnCoursClassiques(1);
        }
        #endregion

        #region Getters/Setters

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

        #endregion

        #region Methodes
        /// <summary>
        /// Récupère la liste des enchères classiques en cours 
        /// </summary>
        /// <param name="idEnchereEnCoursClassique">id enchère classique en cours (1)</param>
        public void GetListeEncheresEnCoursClassiques(int idEnchereEnCoursClassique)
        {
            Task.Run(async () =>
            {
                do
                {
                    MaListeEncheresEnCoursClassique = await _apiServices.GetAllAsyncID<Enchere>("api/getEncheresEnCours", Enchere.CollClasse, "IdTypeEnchere", idEnchereEnCoursClassique);
                    Enchere.CollClasse.Clear();
                    Thread.Sleep(2000);
                }
                while (true);

            });     
        }
        #endregion
    }
}
