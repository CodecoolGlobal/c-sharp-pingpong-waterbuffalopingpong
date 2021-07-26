using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Shapes;

namespace PingPong
{
    class Ball
    {
        private static Dictionary<string, double> Direction = new Dictionary<string, double>();

        public static void Move(Rectangle rectangle)
        {
            if (!Direction.ContainsKey("leftMargin")) SetDirection();
            double leftMargin = rectangle.Margin.Left;
            double topMargin = rectangle.Margin.Top;
            if (rectangle.Margin.Left >= 744)
            {
                SideBounce();
            }
            else if (rectangle.Margin.Left <= -744)
            {
                SideBounce();
            }
            else if (topMargin <= 0)
            {
                TopBounce();
            }

            if (topMargin >= 365)
            {
                ResetPosition(rectangle);
            }
            else
            {
                leftMargin += Direction["leftMargin"];
                topMargin += Direction["topMargin"];
                rectangle.Margin =
                    new Thickness(leftMargin, topMargin, rectangle.Margin.Right, rectangle.Margin.Bottom);
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

        private static void SetDirection()
        {
            Direction.Clear();
            Direction.Add("leftMargin", new Random().Next(-2, 2));
            Direction.Add("topMargin", new Random().Next(-2, 2));
        }
    }
}