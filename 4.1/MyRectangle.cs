using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
using ShapeDrawer;

namespace ShapeDrawer
{
    public class MyRectangle:Shape
    {
        private int _width, _height;

        public MyRectangle() : this(Color.Green, 0.0f, 0.0f, 100, 100)
        {
        }

        public MyRectangle(Color color, float x, float y, int width, int height) : base(color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
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

        public override void Draw()
        {
            SplashKit.FillRectangle(Color, X, Y, Width, Height);
            if (Selected)
            {
               DrawOutline();
            }
        }

        public override void DrawOutline()
        {
            SplashKit.DrawRectangle(Color.Black, X - 1, Y - 1, Width + 2, Height + 2);
        }

        public override bool IsAt(Point2D pt)
        {
            return (pt.X >= X && pt.X <= X + Width) && (pt.Y >= Y && pt.Y <= Y + Height);
        }
    }
}
