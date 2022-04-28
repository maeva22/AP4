using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace AP4.Services
{
    public static class Storage
    {
        public static async void StockerMotDePasse(string id, string pseudo)
        {
            try
            {
                await SecureStorage.SetAsync("ID", id);
                await SecureStorage.SetAsync("Pseudo", pseudo);
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
            }
        }
    }
}
