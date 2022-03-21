using AP4.Modeles;
using AP4.Services;
using AP4.Vues;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AP4.VueModeles
{
    public class PageEnchereClassiqueVueModele : BaseVueModele
    {
        #region Attributs
        Enchere _lenchere;
        Encherir _lencherir;
        private ObservableCollection<Encherir> _listeEncherirDeLEnchere;
        private readonly Api _apiServices = new Api();

        #endregion
        #region Constructeurs
        public PageEnchereClassiqueVueModele(int param)
        {
            GetActualPrice(true, 6000);
            GetListeEncherir();
        }
        #endregion

        #region Getters/Setters
        public Enchere LEnchere
        {
            get
            {
                return _lenchere;
            }
            set
            {
                SetProperty(ref _lenchere, value);
            }
        }
        public Encherir LEncherir
        {
            get
            {
                return _lencherir;
            }
            set
            {
                SetProperty(ref _lencherir, value);
            }
        }
        public ObservableCollection<Encherir> ListeEncherirDeLEnchere
        {
            get
            {
                return _listeEncherirDeLEnchere;
            }
            set
            {
                SetProperty(ref _listeEncherirDeLEnchere, value);
            }
        }
        #endregion

        #region Methodes

        //Va chercher les donner pour une enchère
        public async Task<Enchere> GetLEnchere(int param)
        {
            LEnchere = await _apiServices.GetOneAsync<Enchere>("api/getEnchere", Enchere.CollClasse, param);
            return LEnchere;
        }
        public async void GetListeEncherir()
        {
            Encherir.CollClasse.Clear();
            ListeEncherirDeLEnchere = await _apiServices.GetAllAsync<Encherir>("api/getLastSixOffer", Encherir.CollClasse);
        }
        private void GetActualPrice(bool loopBack, int delay)
        {
            /*Device.StartTimer(TimeSpan.FromSeconds(delay), () =>
            {
                Task.Run(async () =>
                {
                    LEncherir = await _apiServices.GetOneAsync<Encherir>("api/getActualPrice", "Id", LEnchere.Id);
                    if (LEncherir == null)
                        LEncherir = new Encherir() { PrixEnchere = LEnchere.Prixreserve };
                });
                return loopBack;
            });*/
        }
        #endregion
    }
}
