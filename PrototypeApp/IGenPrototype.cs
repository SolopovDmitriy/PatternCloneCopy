using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypeApp
{
    interface IGenPrototype<T>
    {
        T GenClone();
    }
}
