using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeApp
{
    abstract class Human
    {
        private string _name;
        private string _surname;
        private string _patronimic;
        private DateTime _birthDate;
        public Nationality nationality;
        public Genre genre;

        public string getName()
        {
            return _name;
        }
        public void setName(string newName)
        {
            if (newName.Length >= 2 && newName.Length < 24)
            {
                _name = newName;
            }
            else
            {
                throw new ArgumentException("Новое имя не корректное");
            }
        }
        public string Name {
            get {
                return _name;
            }
            set {
                this.setName(value); //value - новые поступающие данные
            }
        }
        public DateTime BirthDate
        {
            set
            {
                if (value <= DateTime.Now && value > DateTime.Now.AddYears(- 104))
                {
                    _birthDate = value;
                }
                else
                {
                    throw new ArgumentException("Человек не нашего времени");
                }
            }
            get
            {
                    return _birthDate;
            }
        }
        public string Surname
        {
            get;set;
        }
        public string Patronimic
        {
            get; set;
        }
        public Human()
        {
            Name = "noname";
            Surname = "nosurname";
            Patronimic = "nopatronimic";
            BirthDate = DateTime.Now;
            genre = default;
            nationality = default;
        }

        public override string ToString()
        {
            return $"Human: \n\t" +
                $"Name: {Name};\n\t" +
                $"Surname: {Surname};\n\t" +
                $"Patronimic: {Patronimic};\n\t" +
                $"Genre: {genre};\n\t" +
                $"Nationality: {nationality};\n\t" +
                $"Birth Date: {BirthDate.ToShortDateString()}\n\t";
        }
        public Human(string name, string surname, string patronimic, DateTime birthDate, Genre genre, Nationality nationality)
        {
            Name = name;
            Surname = surname;
            Patronimic = patronimic;
            BirthDate = birthDate;
            this.genre = genre;
            this.nationality = nationality;
        }

        public virtual void Show() //возможность переопределить в классе потомке
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(this);
            Console.ResetColor();
        }
    }
}
