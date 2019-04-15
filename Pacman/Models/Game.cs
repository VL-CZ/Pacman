using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Pacman.Models
{
    public class Game : ObservableObject
    {
        /// <summary>
        /// size of the game board
        /// </summary>
        private readonly int _boardSize = 25;

        /// <summary>
        /// game board
        /// </summary>
        public GameBoard Board { get; }

        /// <summary>
        /// players in the game
        /// </summary>
        private readonly List<Player> _players;

        /// <summary>
        /// reference to pacman object
        /// </summary>
        public Pacman Pacman { get; }

        private string _text;
        /// <summary>
        /// text for binding in MainWindow.xaml
        /// </summary>
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// timer
        /// </summary>
        private DispatcherTimer _timer;

        /// <summary>
        /// timer interval in miliseconds
        /// </summary>
        private readonly int _timerInterval = 200;

        public Game()
        {
            Board = new GameBoard(_boardSize);

            Point pacmanPosition = new Point(Board.Size / 2 + 1, Board.Size / 2 + 1); // about center of the board
            Point opponent1Position = new Point(1, 1); // top left corner
            Point opponent2Position = new Point(Board.Size - 2, Board.Size - 2); // bottom right corner

            Pacman pacman = new Pacman(Board, pacmanPosition); // new pacman, assign to property
            Pacman = pacman;

            _players = new List<Player>
            {
                pacman,
                new Opponent(Board, opponent1Position),
                new Opponent(Board, opponent2Position)
            };

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(_timerInterval);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        // Timer tick
        private void Timer_Tick(object sender, EventArgs e)
        {
            //foreach (Player player in _players)
            //{
            //    player.Move();
            //}
            if (Pacman.Alive)
            {
                Pacman.Move();
            }
            else
            {
                Text = "You Lost!";
            }
        }
    }
}
