using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeApp
{
    /*
     * унаследоваться от класса Employee
       реализовать интерфейс IWorker
    */
    class Worker : Employee, IWorker, IGenPrototype<Worker>
    {
        private bool _isWorking;
        private string _workDescription;
        public bool IsWorking {
            get { 
                return _isWorking; 
            }
        }  //поле интерфейса

        public string Work() //метод интерфейса
        {
            return _workDescription;
        }
        public void StopWorking()
        {
            _isWorking = false;
        }

        public void NextTask(string task)
        {
            if (_isWorking == false)
            {
                if(task.Length > 0)
                {
                    _workDescription = task;
                    _isWorking = true;
                }
                else
                {
                    throw new InvalidOperationException("Не понял задачу");
                }
            }
            else
            {
                throw new Exception("Я уже занят, я работаю");
            }
        }
        public Worker():base()
        {
            _isWorking = true;
            _workDescription = "Ведутся работы по организации самой работы";
        }

        public Worker(string name, string surname, string patronimic, DateTime birthDate, Genre genre, Nationality nationality, EducationLevel education, float salary, string workDescription) 
            : base(name, surname, patronimic, birthDate, genre, nationality, education, salary)
        {           
            _isWorking = false;
            this.NextTask(workDescription);           
        }

        public override string ToString()
        {
            return base.ToString() +
                $"\n\tStatus Working: {IsWorking};" +
                $"\n\tCurrent Work: {_workDescription}";
        }

        public Worker GenClone()
        {
            return new Worker
            {
                Name = this.Name,
                Surname = this.Surname,
                Patronimic = this.Patronimic,
                BirthDate = this.BirthDate,
                genre = this.genre,
                nationality = this.nationality,
                educationLevel = this.educationLevel,
                Salary = this.Salary,
                _workDescription = this._workDescription,
                _isWorking = this._isWorking
            };
        }
    }
}
