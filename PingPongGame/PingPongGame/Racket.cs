using System.Windows;
using System.Windows.Shapes;

namespace PingPongGame
{
    class Racket : GameComponent
    {
        public int RacketSpeed { get; set; } = 15;
        public Racket(Rectangle rectangle, MainWindow mainWindow) : base(rectangle, mainWindow)
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