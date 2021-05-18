using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypeApp
{
    class ListOfManagers : IGenPrototype<ListOfManagers>
    {
        private int _counter = 0; //количество занятых элементов
        private int _capacity = 8;
        private int _currentCapacity = 0; //количество ячеек в массива - стартовое
        private IManage[] _managers; //массив - список сотрудников
        
        private enum ChoiseResize
        {
            UP,
            DOWN
        }
        public int Count
        {
            get
            {
                return _counter;
            }
        }

        public ListOfManagers()
        {
            _currentCapacity = _capacity;
            _managers = new IManage[_currentCapacity];
        }

        public void AddManager(IManage manager)
        {
            if (SearchManager(manager) != -1)
            {
                Console.WriteLine("Ошибка. Менеджер " + manager + " уже работает в компании");
                return;
            }
            if (_counter == _currentCapacity) //мест нет
            {
                Resize(ChoiseResize.UP);
            }
            _managers[_counter] = manager;
            _counter++;
        }

        public int SearchManager(IManage manager)
        {
            int delIndex = -1;
            for (int i = 0; i < _counter; i++)
            {
                if (_managers[i] == manager)
                {
                    delIndex = i;
                    break;
                }
            }
            return delIndex; //return -1 если не найден
        }
        public void RemoveManager(IManage manager)
        {
            int ind = SearchManager(manager);
            if (ind == -1) throw new ArgumentOutOfRangeException("");

            for (int i = ind; i < _counter - 1; i++)
            {
                _managers[i] = _managers[i + 1];
            }
            _managers[_counter - 1] = null;
            _counter--;

            if (_counter + _capacity - 1 < _currentCapacity - _capacity)
            {
                Resize(ChoiseResize.DOWN);
            }
            else if (_counter == 0)
            {
                return;
            }
        }
        public IManage[] Managers
        {
            get
            {
                return _managers;
            }
        }

        private void Resize(ChoiseResize resize)
        {
            IManage[] tmp;
            switch (resize)
            {
                case ChoiseResize.UP:
                    {
                        _currentCapacity += _capacity;
                        break;
                    }
                case ChoiseResize.DOWN:
                    {
                        if (_currentCapacity == _capacity) break;
                        if (_counter < _currentCapacity - _capacity)
                        {
                            _currentCapacity -= _capacity;
                        }
                        else if (_counter > _currentCapacity)
                        {
                            throw new ArgumentOutOfRangeException("Неконтролируемое перераспределение");
                        }
                        break;
                    }
            }
            tmp = new IManage[_currentCapacity];
            for (int i = 0; i < _counter; i++)
            {
                tmp[i] = _managers[i];
            }
            _managers = tmp;
        }

       
        public IManage this[int index]
        {
            get
            {
                return _managers[index];
            }
            set
            {
                _managers[index] = value;
            }
        }

        public IManage this[IManage manager]
        {
            get
            {
                return _managers[this.SearchManager(manager)];
            }
            set
            {
                _managers[this.SearchManager(manager)] = value;
            }
        }


        public ListOfManagers GenClone()
        {           
            ListOfManagers listOfManagers = new ListOfManagers();
            listOfManagers._managers = new IManage[this._managers.Length];
            for (int i = 0; i < this._managers.Length; i++)
            {
                if (this._managers[i] != null)
                {
                    listOfManagers._managers[i] = ((IGenPrototype<IManage>)this._managers[i]).GenClone();
                }
            }
            listOfManagers._counter = this._counter;
            listOfManagers._capacity = this._capacity;
            listOfManagers._currentCapacity = this._currentCapacity;
            return listOfManagers;
        }

       


    }



}
