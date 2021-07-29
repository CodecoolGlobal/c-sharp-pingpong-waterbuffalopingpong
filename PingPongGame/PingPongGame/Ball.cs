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
        double fixPosition = 10;
        public Ball(System.Windows.Shapes.Rectangle rectangle, MainWindow mainWindow, System.Windows.Shapes.Rectangle racket) : base(rectangle, mainWindow)
        {
            _racket = racket;
            _ball = BaseRectangle;

        }

        public Dictionary<string, double> BallSpeed = new Dictionary<string, double>()
            {{"h_speed", 2}, {"v_speed", 2}};


        public void Move()
        {
            double leftMargin = _ball.Margin.Left;
            double topMargin = _ball.Margin.Top;
            Random random = new Random();

            if (!(leftMargin >= MainWindow.ActualWidth - _ball.ActualWidth * 2 || leftMargin <= -(MainWindow.ActualWidth - _ball.ActualWidth * 2)) && !((topMargin <= 0)) && !(topMargin >= MainWindow.ActualHeight - 1.5 * _racket.ActualHeight - 2 * _ball.ActualHeight &&   // top vizsgalat
                      _racket.Margin.Left - _racket.ActualWidth <= leftMargin &&
                     _racket.Margin.Left + _racket.ActualWidth >= leftMargin)) 
            {
                leftMargin += BallSpeed["h_speed"];
                topMargin += BallSpeed["v_speed"];
                _ball.Margin = new Thickness(leftMargin, topMargin, _ball.Margin.Right, _ball.Margin.Bottom);
                
            }
            else if (leftMargin >= MainWindow.ActualWidth - _ball.ActualWidth * 2 || leftMargin <= -(MainWindow.ActualWidth - _ball.ActualWidth * 2))
            {
                HorizontalBounce();
            }

            else if (topMargin <= 0) { VerticalBounce(); }

            else if (topMargin >= MainWindow.ActualHeight - 1.5 * _racket.ActualHeight - 2 * _ball.ActualHeight &&
                      _racket.Margin.Left - _racket.ActualWidth <= leftMargin &&
                     _racket.Margin.Left + _racket.ActualWidth >= leftMargin)
            { 
                RacketBounce();
                MainWindow.IncreaseScore();
                if (BallSpeed["h_speed"] <= 7) BallSpeed["v_speed"] *= 1.1;
                BallSpeed["h_speed"] = random.Next(-7, 7);
            }

            if (topMargin >= MainWindow.ActualHeight + 50)
            {
                MainWindow.GameOver();
            }
        }

        protected void HorizontalBounce()
        {
            BallSpeed["h_speed"] = -BallSpeed["h_speed"];
            _ball.Margin = new Thickness(_ball.Margin.Left + BallSpeed["h_speed"], _ball.Margin.Top, _ball.Margin.Right, _ball.Margin.Bottom);
        }

        protected void VerticalBounce()
        {
            BallSpeed["v_speed"] = -BallSpeed["v_speed"];
            fixPosition = -fixPosition;
            _ball.Margin = new Thickness(_ball.Margin.Left, 5, _ball.Margin.Right, _ball.Margin.Bottom);
        }

        protected void RacketBounce()
        {
            BallSpeed["v_speed"] = -BallSpeed["v_speed"];
            fixPosition = -fixPosition;
            _ball.Margin = new Thickness(_ball.Margin.Left, 295, _ball.Margin.Right, _ball.Margin.Bottom);
        }


    }
}