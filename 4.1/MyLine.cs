using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private float _endX, _endY;

        public MyLine() : this(Color.Red, 0.0f, 0.0f, 50.0f, 50.0f)
        {
        }

        public MyLine(Color color, float startX, float startY, float endX, float endY) : base(color)
        {
            X = startX;
            Y = startY;
            _endX = endX;
            _endY = endY;
        }

        public float EndX
        {
            get
            {
                return _endX;
            }
            set
            {
                _endX = value;
            }
        }

        public float EndY
        {
            get
            {
                return _endY;
            }
            set
            {
                _endY = value;
            }
        }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }

            SplashKit.DrawLine(Color, X, Y, _endX, _endY);
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, X, Y, 2);
            SplashKit.FillCircle(Color.Black, _endX, _endY, 2);
        }

        public override bool IsAt(Point2D pt)
        {
            Line line = SplashKit.LineFrom(X, Y, _endX, _endY);
            return SplashKit.PointOnLine(pt, line);
            //return (pt.X >= X) && (pt.X <= (X + EndX)) &&
            //(pt.Y >= Y) && (pt.Y <= (Y + EndY));
        }
    }
}
