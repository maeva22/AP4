using System;
using System.Collections.Generic;
using System.Text;

namespace AP4.Modeles
{
    public class EnchereFlash
    {
        #region Attributs

        public static List<EnchereFlash> CollClasse = new List<EnchereFlash>();
        private string _idEnchere;
        private string _idUser;
        private string _id;
        private bool _tag;
        private string _pseudo;
        private string _photo;
        private string _tableauFlash;

        #endregion

        #region Constructeurs


        public EnchereFlash(string id, string id_user, string id_enchere, string pseudo, bool tag, string photo, string tableauFlash)
        {
            _idEnchere = id_enchere;
            _id = id;
            EnchereFlash.CollClasse.Add(this);
            _tag = tag;
            _pseudo = pseudo;
            _photo = photo;
            _idUser = id_user;
            _tableauFlash = tableauFlash;
        }


        #endregion

        #region Getters/Setters
        public string IdEnchere { get => _idEnchere; set => _idEnchere = value; }
        public string Id { get => _id; set => _id = value; }
        public bool Tag { get => _tag; set => _tag = value; }
        public string Pseudo { get => _pseudo; set => _pseudo = value; }
        public string Photo { get => _photo; set => _photo = value; }
        public string IdUser { get => _idUser; set => _idUser = value; }
        public string TableauFlash { get => _tableauFlash; set => _tableauFlash = value; }
        #endregion

        #region Methodes

        #endregion
    }
}
