using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace PingPongGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Ball _ball;
        private Racket _racket;
        private Gem _gem;
        private int points = 0;
        public static bool IsGemActive = false;
        private bool drop;
        private int chance = 0;
        private int activeTime = 0;
        private int _progress = 0;

        DispatcherTimer timer1;
        DispatcherTimer gemTimer;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += Window_Loaded;
            _ball = new Ball(ball, this, racket);
            _racket = new Racket(racket, this);
            _gem = new Gem(gem, this, racket, _ball);
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.None;
            timer1 = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 0, 1)
            };
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            gemTimer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 1)
            };
            gemTimer.Tick += new EventHandler(GemTimer_Tick);
            gemTimer.Start();
        }

        private void GemTimer_Tick(object sender, EventArgs e)
        {
            if (!IsGemActive)
            {
                chance++;
                _gem.Drop(ref drop, ref chance);
            }
            if (IsGemActive) activeTime++;
            if (activeTime == 20)
            {
                _gem.ResetGemFuctionality();
                IsGemActive = false;
                activeTime = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_progress == 100) Victory();
            _ball.Move();
            if (drop) { _gem.Move(ref drop); }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (timer1.IsEnabled)
            {
                if (e.Key == Key.D) { _racket.Move("Right"); }
                if (e.Key == Key.A) { _racket.Move("Left"); }
            }
            if (e.Key == Key.Escape) { Close(); }
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
            _progress += 5;
            progress.Text = $"{_progress}%";
            score.Text = $"Score: {points}";
        }

        public void Victory()
        {
            gemTimer.Stop();
            timer1.Stop();
            victory.Visibility = Visibility.Visible;
            ball.Visibility = Visibility.Hidden;
            racket.Visibility = Visibility.Hidden;
            score.Visibility = Visibility.Hidden;
        }

        public void GameOver()
        {
            timer1.Stop();
            gemTimer.Stop();
            racket.Visibility = Visibility.Hidden;
            score.Visibility = Visibility.Hidden;
            gameOver.Visibility = Visibility.Visible;
            gameOver.Text += $"\nYour final score was {points}!";
        }

    }
}
