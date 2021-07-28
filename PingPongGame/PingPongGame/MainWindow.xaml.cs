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
        private Ball _ball;
        private Racket _racket;

        System.Windows.Threading.DispatcherTimer timer1;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += Window_Loaded;
            _ball = new Ball(ball, this, racket);
            _racket = new Racket(racket, this);
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer1 = new System.Windows.Threading.DispatcherTimer();
            Cursor = Cursors.None;
            timer1.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _ball.Move();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D) { _racket.Move("Right"); }
            if (e.Key == Key.A) { _racket.Move("Left"); }
            if (e.Key == Key.Escape) { this.Close(); }
        }
    }
}
