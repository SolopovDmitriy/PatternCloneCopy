using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypeApp
{
    interface IPrototype //гарантирует обязательную реализацию поведения
    {
        IPrototype Clone(); //обязательная реализация поведения!!!
        /* метод Clone возвращает экземпляр любого класса который реализует интерфейс IPrototype*/
    }
}
