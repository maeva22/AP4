using AP4.Modeles;
using AP4.Services;
using AP4.VueModeles;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AP4.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageInscriptionVue : ContentPage
    {
        readonly Api apiInscription = new Api();
        PageInscriptionVueModele vueModele;
        public PageInscriptionVue()
        {
            InitializeComponent();
            BindingContext = vueModele = new PageInscriptionVueModele();
        }

        /// <summary>
        /// Ajout de la photo de l'utilisateur qui va le chercher dans son téléphone
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private MediaFile _mediaFile;
        async void AddPhoto(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Error", "This is not support on your device.", "OK");
                return;
            }
            else
            {
                var mediaOption = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium
                };
                _mediaFile = await CrossMedia.Current.PickPhotoAsync();
                if (_mediaFile == null) return;
                Photo.Source = ImageSource.FromStream(() => _mediaFile.GetStream());
            }
        }

        Regex EmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        /// <summary>
        /// code pour vérifier si l'adresse email est valide 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return EmailRegex.IsMatch(email);
        }

        /// <summary>
        /// code pour que l'utilisateur puisse s'inscrire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void CommandBouttonInscription(object sender, EventArgs e)
        {   // verifir si l'utilisateur a rentre toutes les informations demande
            if (!string.IsNullOrEmpty(EmailEntry.Text) && !string.IsNullOrEmpty(PasswordEntry.Text)
                && !string.IsNullOrEmpty(PasswordVerifyEntry.Text) && !string.IsNullOrEmpty(PseudoEntry.Text)
                && !string.IsNullOrEmpty(Photo.ToString()))
            {
                // vérifie que l'email saisie est correct
                if (ValidateEmail(EmailEntry.Text))
                {

                    // vérifier que le mot de passe entré et le même entré dans le mot de passe de vérification
                    if (PasswordEntry.Text == PasswordVerifyEntry.Text)
                    {
                        User unUser = new User(EmailEntry.Text, PasswordEntry.Text, PseudoEntry.Text, null);
                        vueModele.PostUser(unUser);

                        await DisplayAlert("Bravo", "enregistrement réussi", "ok");
                        Application.Current.MainPage = new PageConnexionVue();
                    }
                    else
                    {
                        await DisplayAlert("Erreur", "Vos mots de passes ne sont pas les mêmes", "ok");
                    }
                }
                else
                {
                    await DisplayAlert("Erreur", "Votre adresse email n'est pas valide", "ok");
                }
            }
            else
            {
                await DisplayAlert("Erreur", "Vous n'avez pas remplis tous les champs nécessaire !", "ok");
            }
        }
    }
}