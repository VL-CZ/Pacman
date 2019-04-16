using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Models
{
    public class Pacman : Player
    {
        private int _score;
        /// <summary>
        /// score in the game
        /// </summary>
        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                RaisePropertyChanged();
            }
        }

        public Pacman(GameBoard board, Point position) : base(board, position)
        {
            Orientation = Direction.Right;
        }

        /// <summary>
        /// execute move
        /// </summary>
        public override void Move()
        {
            CheckDeath();

            int horizontalShift = 0;
            int verticalShift = 0;
            switch (Orientation)
            {
                case Direction.Left:
                    horizontalShift--;
                    break;
                case Direction.Up:
                    verticalShift--;
                    break;
                case Direction.Right:
                    horizontalShift++;
                    break;
                case Direction.Down:
                    verticalShift++;
                    break;
                default:
                    break;
            }

            SetBoardToNewPosition(new Point(Position.Coord1 + verticalShift, Position.Coord2 + horizontalShift));

        }

        /// <summary>
        /// check if box with pacman contains food
        /// </summary>
        public void CheckScore()
        {
            if (_board[Position].Status == BoxStatus.Food)
                Score++;
        }

        /// <summary>
        /// check collision with opponent
        /// </summary>
        public void CheckDeath()
        {
            if (_board[Position].Status == BoxStatus.Opponent)
                Alive = false;
        }
    }
}
