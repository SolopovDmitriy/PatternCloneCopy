using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PrototypeApp
{
    class Circle : Shape, IGenPrototype<Circle>
    {
        private int _radius;
        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }
        public Circle(): base()
        {
            _radius = default;
        }
        public Circle(int x, int y, int radius , Color color) : base(x, y, color)
        {
            Radius = radius;
        }
        public override string ToString()
        {
            return base.ToString() + $"Radius: {Radius}";
        }
        public Circle GenClone()
        {
            return new Circle { X = this.X, Y = this.Y, Color = this.Color, Radius = this.Radius };
        }
    }
}
