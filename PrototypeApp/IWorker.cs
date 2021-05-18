using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeApp
{
    interface IWorker
    {
        string Work(); //раз рабочий  - значит работать
        bool IsWorking { get; } //статус выполнения работы - работает или нет
    }
}
