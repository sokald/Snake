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

namespace Snake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MySnake _snake;
        private static readonly int SIZE = 10;

        public MainWindow()
        {
            InitializeComponent();

            InitBoard();
            InitSnake();
        }

        void InitBoard()
        {
            for (int i = 0; i < grid.Width / SIZE; i++ )
            {
                ColumnDefinition columnDefinitions = new ColumnDefinition();
                columnDefinitions.Width = new GridLength(SIZE);
                grid.ColumnDefinitions.Add(columnDefinitions);
            }

            for (int j = 0; j < grid.Height / SIZE; j++ )
            {
                RowDefinition rowDefinition = new RowDefinition();
                RowDefinition.Height = new GridLength(SIZE);
                grid.RowDefinitions.Add(RowDefinition);
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

    }
}
