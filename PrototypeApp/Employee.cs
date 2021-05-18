using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeApp
{
    abstract class Employee: Human
    {
        public EducationLevel educationLevel;
        private float _salary;
        public float Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                if (value >= 0.0f && value < float.MaxValue)
                {
                    _salary = value;
                }
                else
                {
                    throw new ArgumentException("Что - то не так с зарплатой");
                }
            }
        }

        public Employee() : base()
        {
            Salary = default;
        }
        public Employee(string name, string surname, string patronimic, DateTime birthDate, Genre genre, Nationality nationality, EducationLevel education,  float salary) 
            : base(name, surname, patronimic, birthDate, genre, nationality)
        {
            this.educationLevel = education;
            Salary = salary;
        }

        public override string ToString()
        {
            return base.ToString() +
                $"EducationLevel: {educationLevel}; " +
                $"\n\tSalary: {Salary}; ";
        }

        public new void Show()
        {
            //я новый метод, я затираю метод базового класса
            base.Show();
            Console.WriteLine(this);
        }

    }
}
