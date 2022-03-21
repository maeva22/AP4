﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AP4.Modeles
{
    public class User
    {
        #region Attributs

        public static List<User> CollClasse = new List<User>();

        private string _email;
        private string _password;
        private string _pseudo;
        private byte[] _photo;

        #endregion

        #region Constructeurs

        public User(string email, string password, string pseudo, byte[] photo)
        {
            User.CollClasse.Add(this);
            _email = email;
            _password = password;
            _pseudo = pseudo;
            _photo = photo;
        }

        #endregion

        #region Getters/Setters
        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }
        public string Pseudo { get => _pseudo; set => _pseudo = value; }
        public byte[] Photo { get => _photo; set => _photo = value; }
        #endregion

        #region Methodes

        #endregion
    }
}