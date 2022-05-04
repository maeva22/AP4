using AP4.Modeles;
using AP4.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AP4.VueModeles
{
    public class PageEnchereFlashVueModele : BaseVueModele
    {
        #region Attributs 
        private Enchere _lenchere;
        private Encherir _prixActuel;
        private bool _btnParticipation;
        private string _idUserGagnant;
        private string _pseudoUser;
        public DecompteTimer tmps;
        private int _tempsRestantJour;
        private int _tempsRestantHeures;
        private int _tempsRestantMinutes;
        private int _tempsRestantSecondes;
        private readonly Api _apiServices = new Api();


        #endregion
        #region Constructeurs 
        public PageEnchereFlashVueModele(Enchere param)
        {
            _lenchere = param;
            this.GetParticiper();
            this.GetActualPrice();
            
            CommandBoutonEncherir = new Command(Participer);
        }
        #endregion

        #region Getters/Setters
        public Enchere LEnchere
        {
            get { return _lenchere; }
            set { SetProperty(ref _lenchere, value); }
        }
        public Encherir PrixActuel
        {
            get { return _prixActuel; }
            set { SetProperty(ref _prixActuel, value); }
        }
        public bool BtnParticipation
        {
            get { return _btnParticipation; }
            set { SetProperty(ref _btnParticipation, value); }
        }
        public ICommand CommandBoutonEncherir { get; }

        public string IdUserGagnant
        {
            get => _idUserGagnant;
            set => _idUserGagnant = value;
        }
        public string PseudoUser
        {
            get => _pseudoUser;
            set => _pseudoUser = value;
        }
        public int TempsRestantHeures
        {
            get { return _tempsRestantHeures; }
            set { SetProperty(ref _tempsRestantHeures, value); }
        }
        public int TempsRestantJour
        {
            get { return _tempsRestantJour; }
            set { SetProperty(ref _tempsRestantJour, value); }
        }
        public int TempsRestantMinutes
        {
            get { return _tempsRestantMinutes; }
            set { SetProperty(ref _tempsRestantMinutes, value); }
        }
        public int TempsRestantSecondes
        {
            get { return _tempsRestantSecondes; }
            set { SetProperty(ref _tempsRestantSecondes, value); }
        }
        #endregion

        #region Methodes
        /// <summary>
        /// permet d'avoir le prix actuel de l'enchère  actualisé toutes les 2 secondes
        /// </summary>
        private void GetActualPrice()
        {
            Task.Run(async () =>
            {
                do
                {
                    PrixActuel = await _apiServices.GetOneAsyncID<Encherir>("api/getActualPrice", Encherir.CollClasse, LEnchere.Id.ToString());
                    Encherir.CollClasse.Clear();
                    Thread.Sleep(2000);
                }
                while (true);

            });
        }
        /*
        /// <summary>
        /// permet de savoir combien de temps en jours, en heures, en minutes et secondes il reste entre la date de début et de fin
        /// </summary>
        /// <param name="param">date de la fin de l'enchère</param>
        public void GetTimerRemaining(DateTime param)
        {
            DateTime datefin = param;
            TimeSpan interval = datefin - DateTime.Now;


            Task.Run(() =>
            {
                tmps.Start(interval);
                do
                {
                    TempsRestantJour = tmps.TempsRestant.Days;
                    TempsRestantHeures = tmps.TempsRestant.Hours;
                    TempsRestantMinutes = tmps.TempsRestant.Minutes;
                    TempsRestantSecondes = tmps.TempsRestant.Seconds;
                }
                while (tmps.TempsRestant > TimeSpan.Zero);
            });
        }*/
        /// <summary>
        /// Permet d'ajouter un nouveau participant à l'enchère flash
        /// </summary>
        public async void Participer()
        {
            EnchereFlash uneEnchereFlash = new EnchereFlash("", await SecureStorage.GetAsync("ID"), LEnchere.Id.ToString(), "", false, "", LEnchere.TableauFlash);

            int participant = await _apiServices.PostAsync<EnchereFlash>(uneEnchereFlash, "api/postPlayerFlash");

            if (participant != 0) this.GetParticiper();
        }
        /// <summary>
        /// Permet de savoir si l'utilisateur est déjà un participant ou non 
        /// </summary>
        public async void GetParticiper()
        {
            EnchereFlash uneEnchereFlash = new EnchereFlash("", await SecureStorage.GetAsync("ID"), LEnchere.Id.ToString(), "", false, "", "");
            EnchereFlash leParticipant = await _apiServices.GetOneAsync<EnchereFlash>("api/getPlayerFlashByID", EnchereFlash.CollClasse, uneEnchereFlash);
            if (leParticipant == null)
            { BtnParticipation = true; }
            else
            { BtnParticipation = false; }
        }
        /// <summary>
        /// Permet d'enchérir sur l'enchère
        /// </summary>
        public async void EncherirFlash()
        {
            IdUserGagnant = await SecureStorage.GetAsync("ID");
            EnchereFlash lEnchereFlash = new EnchereFlash("", await SecureStorage.GetAsync("ID"), LEnchere.Id.ToString(), "", false, "", LEnchere.TableauFlash);

            await _apiServices.PostAsync<EnchereFlash>(lEnchereFlash, "api/postEncherirFlashManuel");
            lEnchereFlash = await _apiServices.GetOneAsync<EnchereFlash>("api/getPlayerFlashByID", EnchereFlash.CollClasse, lEnchereFlash);
            lEnchereFlash = await _apiServices.GetOneAsync<EnchereFlash>("api/getJoueurActif", EnchereFlash.CollClasse, lEnchereFlash);

        }

        public void GestionPhaseEncherir()
        {
            tmps = new DecompteTimer();
            DateTime datefin = DateTime.Now.AddSeconds(30);
            TimeSpan interval = datefin - DateTime.Now;
            tmps.Start(interval);
            this.GetTimer();
        }
        private bool OnCancel = false;
        public void GetTimer()
        {
            Task.Run(async () =>
            {

                while (OnCancel == false)
                {
                    TempsRestantJour = tmps.TempsRestant.Days;
                    TempsRestantHeures = tmps.TempsRestant.Hours;
                    TempsRestantMinutes = tmps.TempsRestant.Minutes;
                    TempsRestantSecondes = tmps.TempsRestant.Seconds;

                    if (tmps.TempsRestant <= TimeSpan.Zero)
                    {
                        tmps.Stop();
                    }
                }

            });


        }
        public async void RencherirJePasse()
        {
            EnchereFlash uneEnchereFlash = new EnchereFlash("", await SecureStorage.GetAsync("ID"), LEnchere.Id.ToString(), "", false, "", LEnchere.TableauFlash);

            int resultat = await _apiServices.PostAsync<EnchereFlash>(uneEnchereFlash, "api/postEncherirFlashJePasse");
            uneEnchereFlash = await _apiServices.GetOneAsync<EnchereFlash>("api/getPlayerFlashByID", EnchereFlash.CollClasse, uneEnchereFlash);
            uneEnchereFlash = await _apiServices.GetOneAsync<EnchereFlash>("api/getJoueurActif", EnchereFlash.CollClasse, uneEnchereFlash);

        }
        #endregion
    }
}
