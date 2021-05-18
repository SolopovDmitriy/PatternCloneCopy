using PrototypeApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeApp
{
    class Manager : Employee, IManage, IGenPrototype<Manager> 
    {
        private IWorker[] _workers; //список рабочих текущего экземпляра менеджера
        public IWorker[] Workers { //поле получения доступа к рабочим текущего менеджера
            get
            {
                return _workers;
            }
        }
        public void addWorker(IWorker worker)
        {

        }
        public void removeWorker(IWorker worker)
        {

        }
        public IWorker GetWorker(int index)
        {
            throw new NotImplementedException(); //заглушка
        }


        public IWorker GetWorker(string workDescription)
        {
            for (int i = 0; i <= _workers.Length; i++)
            {
                if (_workers[i].Work() == workDescription)
                {
                    return _workers[i];
                }
            }
            return null;
        }


        public bool PushWork(string task, IWorker[] workers)
        {
            return true;
        }


        public Manager()
        {
            _workers = new IWorker[10];
        }


        public void Control()
        {
            throw new NotImplementedException();
        }

        public void Organize()
        {
            throw new NotImplementedException();
        }

        public Manager GenClone()
        {
            Manager manager = new Manager
            {
                Name = this.Name,
                Surname = this.Surname,
                Patronimic = this.Patronimic,
                BirthDate = this.BirthDate,
                genre = this.genre,
                nationality = this.nationality,
                educationLevel = this.educationLevel,
                Salary = this.Salary
            };

            manager._workers = new IWorker[this._workers.Length];
            for (int i = 0; i < _workers.Length; i++)
            {
                if (this._workers[i] != null)
                {
                    manager._workers[i] = ((IGenPrototype<Worker>)this._workers[i]).GenClone();
                }
            }
            return manager;
        }

    }
}
