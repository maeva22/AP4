using AP4.Interfaces;
using AP4.Modeles;
using AP4.Services;
using AP4.VueModeles;
using Plugin.Media.Abstractions;
using System;
using System.IO;
using System.Text.RegularExpressions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AP4.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageInscriptionVue : ContentPage
    {
        public string Photo64
        {
            get; set;
        }

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
        async void AddPhoto(object sender, EventArgs e)
        {
            (sender as Button).IsEnabled = false;
            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    stream.CopyTo(memory);
                    byte[] data = memory.ToArray();
                    Photo1.Source = ImageSource.FromStream(() => new MemoryStream(data));
                    Photo64 = Convert.ToBase64String(data);
                }

            }
            (sender as Button).IsEnabled = true;
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
                && !string.IsNullOrEmpty(Photo64))
            {
                // vérifie que l'email saisie est correct
                if (ValidateEmail(EmailEntry.Text))
                {
                    // vérifier que le mot de passe entré et le même entré dans le mot de passe de vérification
                    if (PasswordEntry.Text == PasswordVerifyEntry.Text)
                    {
                        User unUser = new User(EmailEntry.Text, PasswordEntry.Text, PseudoEntry.Text, null, 0);
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