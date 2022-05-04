using Microsoft.VisualStudio.TestTools.UnitTesting;
using AP4.VueModeles;
using System;
using System.Collections.Generic;
using System.Text;
using AP4.Modeles;
using AP4.Services;

namespace AP4.VueModeles.Tests
{
    [TestClass()]
    public class PageConnexionVueModeleTests
    {
        [TestMethod()]
        public async void OnSubmitTest()
        {
            string username = "maeva.desab@gmail.com";
            string password = "toto";
            Api api = new Api();
            User unUser = new User(username, password, "test", "test", 0);
            User user = await api.GetOneAsync<User>("api/getUserByMailAndPass", User.CollClasse, unUser);
            Assert.IsNotNull(user);
        }
    }
}