using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Shapes;

namespace PingPong
{
    class Ball
    {
        private static Dictionary<string, double> Direction = new Dictionary<string, double>()
            {{"leftMargin", 0}, {"topMargin", 0}};

        private static Random random = new Random();

        public static void Move(Rectangle ball, Rectangle paddle, MainWindow mainWindow)
        {
            if (Direction["leftMargin"] == 0) SetDirection();
            double leftMargin = ball.Margin.Left;
            double topMargin = ball.Margin.Top;
            if (ball.Margin.Left >= mainWindow.ActualWidth - ball.ActualWidth)
            {
                SideBounce();
            }
            else if (ball.Margin.Left <= -(mainWindow.ActualWidth - ball.ActualWidth))
            {
                SideBounce();
            }
            else if (topMargin <= 0)
            {
                TopBounce();
            }
            else if (topMargin >= mainWindow.ActualHeight - 1.5 * paddle.ActualHeight - 2 * ball.ActualHeight)
            {
                if (paddle.Margin.Left - paddle.ActualWidth <= ball.Margin.Left &&
                    paddle.Margin.Left + paddle.ActualWidth >= ball.Margin.Left)
                {
                    PaddleBounce();
                }
            }


            if (topMargin >= mainWindow.ActualHeight - ball.ActualHeight * 1.75)
            {
                ResetPosition(ball, mainWindow);
            }
            else
            {
                leftMargin += Direction["leftMargin"];
                topMargin += Direction["topMargin"];
                ball.Margin =
                    new Thickness(leftMargin, topMargin, ball.Margin.Right, ball.Margin.Bottom);
            }
        }

        private static void ResetPosition(Rectangle rectangle, MainWindow mainWindow)
        {
            double leftMargin = random.NextDouble() * (mainWindow.ActualWidth - rectangle.ActualWidth * 2) * 2 -
                                (mainWindow.ActualWidth - rectangle.ActualWidth * 2);
            rectangle.Margin = new Thickness(leftMargin, 10, rectangle.Margin.Right, rectangle.Margin.Bottom);
            SetDirection();
        }

        private static void SideBounce()
        {
            Direction["leftMargin"] = -Direction["leftMargin"];
        }

        private static void TopBounce()
        {
            Direction["topMargin"] = -Direction["topMargin"];
        }

        private static void PaddleBounce()
        {
            Direction["topMargin"] = -Direction["topMargin"];
        }

        private static void SetDirection()
        {
            Direction["leftMargin"] = random.Next(-1, 1);
            Direction["topMargin"] = random.Next(-1, 1);
            if (Direction["leftMargin"] == 0 || Direction["topMargin"] == 0) SetDirection();
        }
    }
}