using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeApp
{
    interface IManage
    {
        void Control();
        void Organize();
        void addWorker(IWorker worker);
        void removeWorker(IWorker worker);
        bool PushWork(string task, IWorker[] workers);

        IWorker[] Workers { get; } //дать возможность получить доступ к сотрудникам
    }
}
