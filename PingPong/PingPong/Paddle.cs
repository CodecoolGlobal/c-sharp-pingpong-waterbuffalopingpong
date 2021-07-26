using System.Windows;

namespace PingPong
{
    public static class Paddle
    {
        public static void Move(System.Windows.Shapes.Rectangle rectangle, string direction)
        {
            var leftMargin = rectangle.Margin.Left;
            {
                switch (direction)
                {
                    case "Right":
                        if (leftMargin <= 600) leftMargin += 10;
                        break;
                    case "Left":
                        if (leftMargin >= -600) leftMargin -= 10;
                        break;
                }
            }
            rectangle.Margin = new Thickness(leftMargin, rectangle.Margin.Top, rectangle.Margin.Right,
                rectangle.Margin.Bottom);
        }
    }
}