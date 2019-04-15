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

        public Direction Orientation { get; set; }

        public Pacman(GameBoard board, Point position) : base(board, position)
        {
            Orientation = Direction.Right;
        }

        public override void Move()
        {
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

        public void CheckScore()
        {
            if (_board[Position].Status == BoxStatus.Food)
                Score++;
        }

        public void CheckDeath()
        {
            if (_board[Position].Status == BoxStatus.Opponent)
                Alive = false;
        }

        /// <summary>
        /// chang
        /// </summary>
        private void CheckPosition()
        {

        }
    }
}
