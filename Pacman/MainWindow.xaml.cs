﻿using Pacman.Models;
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

namespace Pacman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game _game;

        public MainWindow()
        {
            InitializeComponent();
            _game = new Game();
            DataContext = _game;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Direction direction = Direction.Left;
            switch (e.Key)
            {
                case Key.Left:
                    direction = Direction.Left;
                    break;
                case Key.Up:
                    direction = Direction.Up;
                    break;
                case Key.Right:
                    direction = Direction.Right;
                    break;
                case Key.Down:
                    direction = Direction.Down;
                    break;
                default:
                    break;
            }
            _game.Pacman.Orientation = direction;
        }
    }
}
