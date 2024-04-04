using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Shape
    {
        private Color _color;
        private float _x, _y;
        private int _width, _height;
        private bool _selected;

        public Shape()
        {
            _color = Color.Green;
            _x = 0.0f;
            _y = 0.0f;
            _width = 100;
            _height = 100;
        }

        public Color Color
        {
            get 
            { 
                return _color; 
            }
            set 
            {
                _color = value;
            }
        }

        public float X
        {
            get 
            { 
                return _x; 
            }
            set 
            { 
                _x = value; 
            }
        }

        public float Y
        {
            get 
            { 
                return _y; 
            }
            set 
            {
                _y = value;
            }
        }

        public int Width
        {
            get 
            {
                return _width;
            }
            set 
            {
                _width = value;
            }
        }

        public int Height
        {
            get 
            { 
                return _height;
            }
            set 
            {
                _height = value;
            }
        }

        public void Draw()
        {
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
            
            if (_selected)
            {
                DrawOutline();
            }
        }

        public bool IsAt(Point2D pt)
        {
            return (pt.X >= X && pt.X <= X + Width) && (pt.Y >= Y && pt.Y <= Y + Height);
        }

        public bool Selected
        {
            get
            {
                return _selected; 
            }
            set
            {
                _selected = value; 
            }
        }

        public void DrawOutline()
        {
            SplashKit.DrawRectangle(Color.Black, _x - 1, _y - 1, _width + 2, _height + 2);
        }
    }
}
