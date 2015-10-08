﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snake
{
    class SnakePart
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Rectangle Rect { get; private set; }

        public SnakePart(int x, int y) 
        {
            X = x;
            Y = y;
            Rect = new Rectangle();
            Rect.Width = Rect.Height = 9;
            Rect.Fill = Brushes.Black;
        }
    }
}
