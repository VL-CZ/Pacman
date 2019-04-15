using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Models
{
    public abstract class Player : ObservableObject
    {
        private GameBoard _board;
        /// <summary>
        /// is player alive?
        /// </summary>
        public bool Alive { get; private set; }

        /// <summary>
        /// position in the map
        /// </summary>
        public Point Position { get; private set; }

        public Player(GameBoard board)
        {
            _board = board;
            Alive = true;
        }

        public abstract void Move();

        public void SetBoardToCurrentPosition(Point newPosition)
        {
            _board[Position.Coord1, Position.Coord2].Status = BoxStatus.Free; // unset old position
            Position = newPosition;
            if (this is Pacman)
            {
                _board[Position.Coord1, Position.Coord2].Status = BoxStatus.Pacman;
            }
            else if(this is Opponent)
            {
                _board[Position.Coord1, Position.Coord2].Status = BoxStatus.Opponent;
            }
        }
    }
}
