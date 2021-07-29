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
        private int points = 0;

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
            if (timer1.IsEnabled)
            {
                if (e.Key == Key.D) { _racket.Move("Right"); }
                if (e.Key == Key.A) { _racket.Move("Left"); }
            }
            if (e.Key == Key.Escape) { this.Close(); }
            if (e.Key == Key.Space)
            {
                if (timer1.IsEnabled)
                {
                    HandlePause();
                } else
                {
                    HandleContinue();
                }
            }
        }

        private void HandlePause()
        {
            timer1.Stop();
            pauseBox.Visibility = Visibility.Visible;
        }

        private void HandleContinue()
        {
            timer1.Start();
            pauseBox.Visibility = Visibility.Hidden;
        }

        public void IncreaseScore()
        {
            points += 1;
            score.Text = $"Score: {points}";
        }

        public void GameOver()
        {
            timer1.Stop();
            gameOver.Visibility = Visibility.Visible;
        }
    }
}
