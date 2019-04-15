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

        public Direction Orientation { get; private set; }

        public Pacman(GameBoard board) : base(board)
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
                case Direction.Top:
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

            return new Point(bp.Coord1 + verticalShift, bp.Coord2 + horizontalShift);
        }
    }
}
