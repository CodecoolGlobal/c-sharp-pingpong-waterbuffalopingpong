using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;

namespace PingPongGame
{
    class Rectangle
    {

        protected MainWindow MainWindow;

        protected System.Windows.Shapes.Rectangle BaseRectangle;

        public Rectangle(System.Windows.Shapes.Rectangle rectangle, MainWindow mainWindow)
        {
            MainWindow = mainWindow;
            BaseRectangle = rectangle;
        }

    }
}
