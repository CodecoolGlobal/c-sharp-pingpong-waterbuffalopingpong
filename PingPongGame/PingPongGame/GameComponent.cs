using System.Windows.Shapes;

namespace PingPongGame
{
    class GameComponent
    {

        protected MainWindow MainWindow;

        protected Rectangle BaseRectangle;

        public GameComponent(Rectangle rectangle, MainWindow mainWindow)
        {
            MainWindow = mainWindow;
            BaseRectangle = rectangle;
        }

    }
}
