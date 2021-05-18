using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypeApp
{
    class Square : Shape, ICloneable
    {
        object ICloneable.Clone()
        {
            throw new NotImplementedException();
        }
    }
}
