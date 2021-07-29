using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace PingPongGame
{
    class Racket : Rectangle
    {
        public int RacketSpeed { get; set; } = 15;
        public Racket(System.Windows.Shapes.Rectangle rectangle, MainWindow mainWindow) : base(rectangle, mainWindow)
        {
        }

        public void Move(string direction)
        {
            var leftMargin = BaseRectangle.Margin.Left;
            {
                switch (direction)
                {
                    case "Right":
                        if (leftMargin <= MainWindow.ActualWidth - BaseRectangle.ActualWidth) leftMargin += RacketSpeed;
                        break;
                    case "Left":
                        if (leftMargin >= -MainWindow.ActualWidth + BaseRectangle.ActualWidth) leftMargin -= RacketSpeed;
                        break;
                }
            }
            BaseRectangle.Margin = new Thickness(leftMargin, BaseRectangle.Margin.Top, BaseRectangle.Margin.Right,
                BaseRectangle.Margin.Bottom);
        }


    }
}