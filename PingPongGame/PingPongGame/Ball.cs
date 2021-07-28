using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace PingPongGame
{
    class Ball : Rectangle
    {
        private readonly System.Windows.Shapes.Rectangle _racket;
        private readonly System.Windows.Shapes.Rectangle _ball;
        private double leftMargin;
        private double topMargin;
        public Ball(System.Windows.Shapes.Rectangle rectangle, MainWindow mainWindow, System.Windows.Shapes.Rectangle racket) : base(rectangle, mainWindow)
        {
            _racket = racket;
            _ball = BaseRectangle;
            leftMargin = _ball.Margin.Left;
            topMargin = _ball.Margin.Top;

        }

        protected Dictionary<string, double> BallSpeed = new Dictionary<string, double>()
            {{"h_speed", 40}, {"v_speed", 40}};


        public void Move()
        {

            if (leftMargin >= MainWindow.ActualWidth - _ball.ActualWidth ||
                    leftMargin <= -(MainWindow.ActualWidth - _ball.ActualWidth))
            {
                HorizontalBounce();
            }

            else if (topMargin <= 0) { VerticalBounce(); }

            else if (topMargin >= MainWindow.ActualHeight - _racket.ActualHeight - _racket.Margin.Bottom &&   // top vizsgalat
                      _racket.Margin.Left - _racket.ActualWidth <= leftMargin &&
                     _racket.Margin.Left + _racket.ActualWidth >= leftMargin) { VerticalBounce(); }  // kell majd score
            else
            {
                leftMargin += BallSpeed["h_speed"];
                topMargin += BallSpeed["v_speed"];
                BaseRectangle.Margin = new Thickness(leftMargin, topMargin, BaseRectangle.Margin.Right, BaseRectangle.Margin.Bottom);
            }

        }





        protected void HorizontalBounce()
        {
            BallSpeed["h_speed"] = -BallSpeed["h_speed"];
        }

        protected void VerticalBounce()
        {
            BallSpeed["v_speed"] = -BallSpeed["v_speed"];
        }



    }
}