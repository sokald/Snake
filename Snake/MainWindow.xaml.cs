using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Snake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MySnake _snake;
        private static readonly int SIZE = 10;
        //direction of the _snake
        private int _directionX = 1;
        private int _directionY = 0;

        private DispatcherTimer _timer;

        public MainWindow()
        {
            InitializeComponent();

            InitBoard();
            InitSnake();
            initTimer();
        }

        void InitBoard()
        {
            for (int i = 0; i < grid.Width / SIZE; i++ )
            {
                ColumnDefinition columnDefinitions = new ColumnDefinition();
                columnDefinitions.Width = new GridLength(SIZE);
                grid.ColumnDefinitions.Add(columnDefinitions);
            }

            for (int j = 0; j < grid.Height / SIZE; j++)
            {
                RowDefinition rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(SIZE);
                grid.RowDefinitions.Add(rowDefinition);
            }
            _snake = new MySnake();
        }

        void InitSnake()
        {
            grid.Children.Add(_snake.Head.Rect);
            foreach (SnakePart snakePart in _snake.Parts)
                grid.Children.Add(snakePart.Rect);

            _snake.RedrawSnake();
        }

        //move snake
        private void MoveSnake()
        {
            for (int i = _snake.Parts.Count - 1; i > 1; i-- )
            {
                _snake.Parts[i].X = _snake.Parts[i - 1].X;
                _snake.Parts[i].Y = _snake.Parts[i - 1].Y;
            }
            _snake.Parts[0].X = _snake.Head.X;
            _snake.Parts[0].Y = _snake.Head.Y;
            _snake.Head.X += _directionX;
            _snake.Head.Y += _directionY;
            _snake.RedrawSnake();
        }

        //timer
        void initTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Interval = new TimeSpan(0,0,0,0,100);
            _timer.Start();
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            MoveSnake();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Left)
            {
                _directionX = -1;
                _directionY = 0;
            }
            if(e.Key == Key.Right)
            {
                _directionX = 1;
                _directionY = 0;
            }
            if(e.Key == Key.Up)
            {
                _directionX = 0; 
                _directionY = -1;
            }
            if (e.Key == Key.Down)
            {
                _directionX = 0;
                _directionY = 1;
            }
        }
    }
}
