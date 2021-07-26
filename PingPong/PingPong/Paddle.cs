using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace PingPong
{
    static class Paddle
    {
        public static void Move(Rectangle rectangle, String direction)
        {
            double leftMargin = rectangle.Margin.Left;
            switch (direction)
            {
                case "Right":
                    leftMargin += 10;
                    break;
                case "Left":
                    leftMargin -= 10;
                    break;
            }

            rectangle.Margin = new Thickness(leftMargin, rectangle.Margin.Top, rectangle.Margin.Right, rectangle.Margin.Bottom);
        }
    }
    }

