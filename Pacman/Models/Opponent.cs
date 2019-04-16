using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Models
{
    public class Opponent : Player
    {
        private Random _generator;

        public Opponent(GameBoard board, Point position) : base(board, position)
        {
            _generator = new Random();
        }

        /// <summary>
        /// executes opponent's move
        /// </summary>
        public override void Move()
        {
            Direction selectedDirection;
            try
            {
                selectedDirection = SelectDirection();
            }
            catch (InvalidOperationException e)
            {
                return;
            }

            int verticalShift = 0, horizontalShift = 0;
            switch (selectedDirection)
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
        /// randomly select direction (valid move)
        /// </summary>
        /// <returns></returns>
        private Direction SelectDirection()
        {
            List<Direction> possibleMoves = new List<Direction>();

            if (_board.IsFree(_board[Position.Coord1 - 1, Position.Coord2])) // up
            {
                possibleMoves.Add(Direction.Up);
            }
            if (_board.IsFree(_board[Position.Coord1 + 1, Position.Coord2])) // down
            {
                possibleMoves.Add(Direction.Down);
            }
            if (_board.IsFree(_board[Position.Coord1, Position.Coord2 - 1])) // left
            {
                possibleMoves.Add(Direction.Left);
            }
            if (_board.IsFree(_board[Position.Coord1, Position.Coord2 + 1])) // right
            {
                possibleMoves.Add(Direction.Right);
            }

            if (possibleMoves.Count == 0) // cannot move
                throw new InvalidOperationException();

            int randomNumber = _generator.Next(0, possibleMoves.Count);
            return possibleMoves[randomNumber];
        }
    }
}
