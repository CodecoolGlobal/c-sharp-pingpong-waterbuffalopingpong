using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Shapes;

namespace PingPong
{
    class Ball
    {
        private static double _level;

        public static void SetLevel(int level)
        {
            _level = level;
        }

        public static void IncreaseLevel()
        {
            _level += 1;
            _direction["leftMargin"] *= _level / (_level - 1);
            _direction["topMargin"] *= _level / (_level - 1);
        }

        private static Dictionary<string, double> _direction = new Dictionary<string, double>()
            {{"leftMargin", 0}, {"topMargin", 0}};

        private static readonly Random Random = new Random();

        public static void Move(Rectangle ball, Rectangle paddle, MainWindow mainWindow)
        {
            if ((int) _direction["leftMargin"] == 0) SetDirection();
            double leftMargin = ball.Margin.Left;
            double topMargin = ball.Margin.Top;
            if (ball.Margin.Left >= mainWindow.ActualWidth - ball.ActualWidth ||
                ball.Margin.Left <= -(mainWindow.ActualWidth - ball.ActualWidth))
            {
                SideBounce();
            }
            else if (topMargin <= 0)
            {
                TopBounce();
            }
            else if (topMargin >= mainWindow.ActualHeight - 1.5 * paddle.ActualHeight - 2 * ball.ActualHeight &&
                     paddle.Margin.Left - paddle.ActualWidth <= ball.Margin.Left &&
                     paddle.Margin.Left + paddle.ActualWidth >= ball.Margin.Left)
            {
                PaddleBounce();
                mainWindow.IncreaseScore();
            }

            if (topMargin >= mainWindow.ActualHeight - ball.ActualHeight * 1.75)
            {
                ResetPosition(ball, mainWindow);
            }
            else
            {
                leftMargin += _direction["leftMargin"];
                topMargin += _direction["topMargin"];
                ball.Margin =
                    new Thickness(leftMargin, topMargin, ball.Margin.Right, ball.Margin.Bottom);
            }
        }

        private static void ResetPosition(Rectangle rectangle, MainWindow mainWindow)
        {
            double leftMargin = Random.NextDouble() * (mainWindow.ActualWidth - rectangle.ActualWidth * 2) * 2 -
                                (mainWindow.ActualWidth - rectangle.ActualWidth * 2);
            rectangle.Margin = new Thickness(leftMargin, 10, rectangle.Margin.Right, rectangle.Margin.Bottom);
            SetDirection();
        }

        private static void SideBounce()
        {
            _direction["leftMargin"] = -_direction["leftMargin"];
        }

        private static void TopBounce()
        {
            _direction["topMargin"] = -_direction["topMargin"];
        }

        private static void PaddleBounce()
        {
            _direction["topMargin"] = -_direction["topMargin"];
        }

        private static void SetDirection()
        {
            while (true)
            {
                _direction["leftMargin"] = Random.Next(-1, 1) * _level;
                _direction["topMargin"] = Random.Next(-1, 1) * _level;
                if ((int) _direction["leftMargin"] == 0 || (int) _direction["topMargin"] == 0) continue;
                break;
            }
        }
    }
}