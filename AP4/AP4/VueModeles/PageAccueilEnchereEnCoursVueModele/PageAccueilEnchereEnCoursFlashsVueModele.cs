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
    public class PageAccueilEnchereEnCoursFlashsVueModele :BaseVueModele
    {
        #region Attributs
        private ObservableCollection<Enchere> _maListeEncheresEnCoursFlashs;

        private readonly Api _apiServices = new Api();
        #endregion

        #region Constructeurs
        public PageAccueilEnchereEnCoursFlashsVueModele()
        {
            GetListeEncheresEnCoursFlashs(3);
        }
        #endregion

        #region Getters/Setters

        public ObservableCollection<Enchere> MaListeEncheresEnCoursFlashs
        {
            get
            {
                return _maListeEncheresEnCoursFlashs;
            }
            set
            {
                SetProperty(ref _maListeEncheresEnCoursFlashs, value);
            }
        }

        #endregion

        #region Methodes
        /// <summary>
        /// Récupère la liste des enchères flashs en cours 
        /// </summary>
        /// <param name="idEnchereEnCoursFlashs">id enchère flash en cours (3)</param>
        public void GetListeEncheresEnCoursFlashs(int idEnchereEnCoursFlashs)
        {
            Task.Run(async () =>
            {
                do
                {
                    MaListeEncheresEnCoursFlashs = await _apiServices.GetAllAsyncID<Enchere>("api/getEncheresEnCours", Enchere.CollClasse, "IdTypeEnchere", idEnchereEnCoursFlashs);
                    Enchere.CollClasse.Clear();
                    Thread.Sleep(2000);
                }
                while (true);

            });
        }
        #endregion
    }
}
