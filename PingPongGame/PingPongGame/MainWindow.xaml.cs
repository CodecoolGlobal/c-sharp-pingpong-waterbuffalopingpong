using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PingPongGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double x;
        double y;
        System.Windows.Threading.DispatcherTimer timer1;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += Window_Loaded;
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.None;
            //border. = true;
            //this.Bounds = Screen.PrimaryScreen.Bounds;
            timer1 = new System.Windows.Threading.DispatcherTimer();
            Cursor = Cursors.None;
            timer1.Interval = new TimeSpan(0, 0, 1);
            timer1.Tick += new EventHandler(timer1_Tick);
            racket.Margin = new Thickness(337, 390, 0, 0);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Cursor.Position.X - (racket.Width / 2);
            //ball.Left += speed_horizontal;
            //ball.Top += speed_vertical;

            //if (ball.Bottom >= racket.Top && ball.Bottom <= racket.Bottom && ball.Left >= racket.Left && ball.Right <= racket.Right)
            //{
            //    speed_vertical += 2;
            //    speed_horizontal += 2;
            //    speed_vertical = -speed_vertical;

            //    points += 1;


            //}

            //if (ball.Left <= playground.Left) { speed_horizontal = -speed_horizontal; }
            //if (ball.Right >= playground.Right) { speed_horizontal = -speed_horizontal; }
            //if (ball.Top >= playground.Top) { speed_vertical = -speed_vertical; }
            //if (ball.Bottom <= playground.Bottom) { timer1.Enabled = false; }

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            x = racket.Margin.Left;
            y = racket.Margin.Top;
            if (e.Key == Key.D) { racket.Margin = new Thickness(x + 15, y, 0, 0); }
            if (e.Key == Key.A) { racket.Margin = new Thickness(x - 15, y, 0, 0); }
            if (e.Key == Key.Escape) { this.Close(); }
        }
    }
}
