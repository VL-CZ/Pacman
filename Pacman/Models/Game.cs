using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Game()
        {
            Board = new GameBoard(_boardSize);
            Pacman pacman = new Pacman(Board);
            _players = new List<Player>
            {
                pacman,
                new Opponent(Board),
                new Opponent(Board)
            };
        }

    }
}
