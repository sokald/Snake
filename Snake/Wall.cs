﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Snake
{
    class Wall
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Rectangle Rect { get; private set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Wall(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Rect.Width = 10 * Width;
            Rect.Height = 10 * Height;
            Rect.Fill = Brushes.Yellow;
        }

    }
}