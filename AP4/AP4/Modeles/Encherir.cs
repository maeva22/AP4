using System;
using System.Collections.Generic;
using System.Text;

namespace AP4.Modeles
{
    public class Encherir
    {
        #region Attributs
        private int _id;
        private int _idEnchere;
        private int _idUser;
        private float _prixEnchere;
        private DateTime _dateEnchere;
        private Enchere _lEnchere;
        private User _leUser;


        public static List<Encherir> CollClasse = new List<Encherir>();

        #endregion

        #region Constructeur
        public Encherir(int id, int idEnchere, int idUser, float prixEnchere)
        {
            Id = id;
            IdEnchere = idEnchere;
            IdUser = idUser;
            PrixEnchere = prixEnchere;
            Encherir.CollClasse.Add(this);
        }
        public Encherir()
        {
        }

        #endregion

        #region Getters/Setters
        public int Id { get => _id; set => _id = value; }
        public int IdEnchere { get => _idEnchere; set => _idEnchere = value; }
        public int IdUser { get => _idUser; set => _idUser = value; }
        public float PrixEnchere { get => _prixEnchere; set => _prixEnchere = value; }
        public DateTime DateEnchere { get => _dateEnchere; set => _dateEnchere = value; }
        public Enchere LEnchere { get => _lEnchere; set => _lEnchere = value; }
        public User LeUser { get => _leUser; set => _leUser = value; }

        #endregion

        #region Methodes
        #endregion
    }
}
