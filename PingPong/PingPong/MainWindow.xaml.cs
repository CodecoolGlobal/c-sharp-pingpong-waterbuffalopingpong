﻿using System;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;


namespace PingPong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer;

        private int Score = 0;

        

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            _timer.Tick += new EventHandler(dispatcherTimer_Tick);
            _timer.Start();
            
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Ball.Move(BallVisual, PaddleVisual, this);
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    HandleEscapeKey();
                    break;
                case Key.Right:
                    Paddle.Move(PaddleVisual, "Right");
                    break;
                case Key.Left:
                    Paddle.Move(PaddleVisual,"Left");
                    break;
                case Key.Space:
                    //game pauses
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

        public void IncreaseScore()
        {
            Score++;
            ScoreVisual.Content = $"Score: {Score}";
        }
    }
}