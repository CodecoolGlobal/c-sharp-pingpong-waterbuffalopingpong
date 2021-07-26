using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Shapes;

namespace PingPong
{
    class Ball
    {
        private static Dictionary<string, double> Direction = new Dictionary<string, double>();

        public static void Move(Rectangle ball, Rectangle paddle, MainWindow mainWindow)
        {

            Console.WriteLine(paddle.ActualWidth);
            if (!Direction.ContainsKey("leftMargin")) SetDirection();
            double leftMargin = ball.Margin.Left;
            double topMargin = ball.Margin.Top;
            if (ball.Margin.Left >= 744)
            {
                SideBounce();
            }
            else if (ball.Margin.Left <= -744)
            {
                SideBounce();
            }
            else if (topMargin <= 0)
            {
                TopBounce();
            }
            else if (topMargin >= 315)
            {
                if (paddle.Margin.Left - paddle.ActualWidth <= ball.Margin.Left && paddle.Margin.Left + paddle.ActualWidth >= ball.Margin.Left)
                {
                    PaddleBounce();
                    mainWindow.IncreaseScore();

                }
            }
            

            if (topMargin >= 365)
            {
                ResetPosition(ball);
            }
            else
            {
                leftMargin += Direction["leftMargin"];
                topMargin += Direction["topMargin"];
                ball.Margin =
                    new Thickness(leftMargin, topMargin, ball.Margin.Right, ball.Margin.Bottom);
            }
        }


        

        private static void ResetPosition(Rectangle rectangle)
        {
            double leftMargin = new Random().NextDouble() * 1480 - 740;
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
            Direction.Clear();
            Direction.Add("leftMargin", new Random().Next(-2, 2));
            Direction.Add("topMargin", new Random().Next(-2, 2));
        }
    }
}