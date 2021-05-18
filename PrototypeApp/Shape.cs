using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PrototypeApp
{
    class Shape : IPrototype
    {
        private int _x;
        private int _y;
        private Color _color;

        public int X
        {
            get { return _x; } set { _x = value; }
        }
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public Shape()
        {
            X = default;
            Y = default;
            Color = default;
        }
        public Shape(int x, int y, Color color)
        {
            X = x;
            Y = y;
            Color = color;
        }
        public override string ToString()
        {
            return $"X - {X}; Y - {Y}; Color - {Color};";
        }
        public IPrototype Clone()
        {
            return new Shape { X = this.X, Y = this.Y, Color = this.Color};
        }
    }
}
