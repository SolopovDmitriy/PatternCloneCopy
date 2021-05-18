using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypeApp
{
    class Director : Employee, IGenPrototype<Director>
    {
        ListOfManagers _managers;
       
        public Director()
        {
            _managers = new ListOfManagers();
            
        }

        public ListOfManagers Managers
        {
            get
            {
                return _managers;
            }
        }


        public void AddManager(IManage manager)
        {
            _managers.AddManager(manager);
        }

        public void AddWorker(IManage manager, IWorker worker)
        {
            // if (!Contains(manager)) cw("Error");            
            manager.addWorker(worker);
        }

        public bool PushWork(string task)
        {
            for (int i = 0; i < Managers.Count; i++)
            {
                IManage manager = Managers[i];                
                if (manager.PushWork(task, manager.Workers))
                {
                    return true;
                }
            }
            return false;
        }

        public void LayOfManager(IManage managerLayOf, IManage managerNew)
        {

            for (int i = managerLayOf.Workers.Length - 1; i >= 0; i--)
            {
                IWorker worker = managerLayOf.Workers[i];
                managerNew.addWorker(worker);
                managerLayOf.removeWorker(worker);

            }
            _managers.RemoveManager(managerLayOf);
            _managers.AddManager(managerNew);
        }
        public void RemoveComandManager(IManage managerRemove)
        {
            _managers.RemoveManager(managerRemove);
        }

        public Director GenClone()
        {
            Director director = new Director
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

            director._managers = this._managers.GenClone();

            return director;
        }
    }
}
