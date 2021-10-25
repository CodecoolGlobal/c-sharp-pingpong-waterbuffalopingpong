using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Shapes;

namespace PingPongGame
{
    class Gem : GameComponent
    {
        private GemColor gemColor = GemColor.BLUE;
        private Ball _ball;
        private Rectangle _racket;
        private Rectangle _gem;
        private readonly Random random = new Random();

        public Gem(Rectangle rectangle, MainWindow mainWindow, System.Windows.Shapes.Rectangle racket, Ball ball) : base(rectangle, mainWindow)
        {
            _gem = BaseRectangle;
            _ball = ball;
            _racket = racket;
        }

        private enum GemColor
        {
            RED,
            YELLOW,
            GREEN,
            BLUE
        }

        public Dictionary<string, double> GemSpeed = new Dictionary<string, double>()
            { {"v_speed", 0}};


        public void GetRandomColor()
        {
            int randInt = random.Next(1, 5);
            switch (randInt)
            {
                case 1:
                    gemColor = GemColor.BLUE;
                //    _gem.Fill = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\feherdaniel\Documents\Projects\CSharp-teamwork-tasks\c-sharp-pingpong-waterbuffalopingpong\PingPongGame\PingPongGame\BlueGem.png")));
                    break;
                case 2:
                    gemColor = GemColor.RED;
                  //  _gem.Fill = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\feherdaniel\Documents\Projects\CSharp-teamwork-tasks\c-sharp-pingpong-waterbuffalopingpong\PingPongGame\PingPongGame\RedGem.png")));
                    break;
                case 3:
                    gemColor = GemColor.YELLOW;
                   // _gem.Fill = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\feherdaniel\Documents\Projects\CSharp-teamwork-tasks\c-sharp-pingpong-waterbuffalopingpong\PingPongGame\PingPongGame\YellowGem.png")));
                    break;
                case 4:
                    gemColor = GemColor.GREEN;
                    //_gem.Fill = new ImageBrush(new BitmapImage(new Uri(@"/C:\Users\feherdaniel\Documents\Projects\CSharp-teamwork-tasks\c-sharp-pingpong-waterbuffalopingpong\PingPongGame\PingPongGame\GreenGem.png")));
                    break;
                default:
                    break;
            }
        }

        public void Drop(ref bool drop, ref int chance)
        {
            int randInt = random.Next(1, 50);
            
            if (chance > randInt)
            {
                chance = 0;
                drop = true;
                GemSpeed["v_speed"] = 2;
            }
        }

        public void ResetPosition()
        {
            _gem.Margin = new Thickness(random.Next(-600, 600), 10, _gem.Margin.Right, _gem.Margin.Bottom);
        }

        public void Move(ref bool drop)
        {
            _gem.Visibility = Visibility.Visible;
            GetRandomColor();
            double topMargin = _gem.Margin.Top;
            if (topMargin >= MainWindow.ActualHeight - 1.5 * _racket.ActualHeight - 2 * _gem.ActualHeight &&
               _racket.Margin.Left - _racket.ActualWidth <= _gem.Margin.Left &&
               _racket.Margin.Left + _racket.ActualWidth >= _gem.Margin.Left)
            {
                GemFunctionality();
                drop = false;
                MainWindow.IsGemActive = true;
                _gem.Visibility = Visibility.Hidden;
                ResetPosition();
            }

            if (topMargin >= MainWindow.ActualHeight + 50)
            {
                drop = false;
                _gem.Visibility = Visibility.Hidden;
                ResetPosition();
            }
            else
            {
                _gem.Margin = new Thickness(_gem.Margin.Left, _gem.Margin.Top + GemSpeed["v_speed"], _gem.Margin.Right, _gem.Margin.Bottom);
            }
        }

        public void GemFunctionality()
        {
            MainWindow.IsGemActive = true;
            switch (gemColor)
            {
                case GemColor.BLUE:
                    _racket.Width *= 2;
                    break;
                case GemColor.RED:
                    _racket.Width /= 2;
                    break;
                case GemColor.YELLOW:
                    _ball.BallSpeed["v_speed"] *= 2;
                    break;
                case GemColor.GREEN:
                    _ball.BallSpeed["v_speed"] /= 2;
                    break;
            }
        }

        public void ResetGemFuctionality()
        {
            switch (gemColor)
            {
                case GemColor.BLUE:
                    _racket.Width /= 2;
                    break;
                case GemColor.RED:
                    _racket.Width *= 2;
                    break;
                case GemColor.YELLOW:
                    _ball.BallSpeed["v_speed"] /= 2;
                    break;
                case GemColor.GREEN:
                    _ball.BallSpeed["v_speed"] *= 2;
                    break;
            }
        }
    }
}
