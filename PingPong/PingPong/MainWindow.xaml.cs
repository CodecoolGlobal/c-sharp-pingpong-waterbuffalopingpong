using System;

using System.Windows;

using System.Windows.Input;


namespace PingPong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    HandleEscapeKey();
                    break;
                
                case Key.Right:
                    //something happens
                    Console.WriteLine("Right key pressed");
                    break;
                case Key.Left:
                    //something happens
                    Console.WriteLine("Left key pressed");
                    break;
                
            }
        }

        private void HandleEscapeKey()
        {
            //pause game
            Console.WriteLine("Not yet implemented.");
            PopUpMenu.Visibility = Visibility.Visible;
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            //resume game
        }
    }
}