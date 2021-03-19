using dio_signup_app.Enums;
using System;

namespace dio_signup_app.Entities
{
    class Series : Entity
    {
        private string _name;
        private string _description;
        private int _releaseYear;
        private Category _category;

        #region Encapsulated Fields
        public string Name { get => _name; protected set => _name = value; }
        public string Description { get => _description; protected set => _description = value; }
        public int ReleaseYear { get => _releaseYear; protected set => _releaseYear = value; }
        public Category Gender { get => _category; protected set => _category = value; }
        #endregion

        public Series(int id, string name, string description, int releaseYear, Category category)
        {
            Id = id;
            _name = name;
            _description = description;
            _releaseYear = releaseYear;
            _category = category;
        }

        public override string ToString()
        {
            string exit = "";
            exit += "Name: " + _name + Environment.NewLine;
            exit += "Descrição: " + _description + Environment.NewLine;
            exit += "Ano de Lançamento: " + _releaseYear + Environment.NewLine;
            exit += "Gênero: " + _category + Environment.NewLine;
            return exit;
        }
    }
}
