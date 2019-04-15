using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Models
{
    public class Game : ObservableObject
    {
        public GameBoard Board { get; }

        /// <summary>
        /// size of the game board
        /// </summary>
        private readonly int _boardSize = 25;

        public Game()
        {
            Board = new GameBoard(_boardSize);
        }

    }
}
