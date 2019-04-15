using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Models
{
    public class Opponent : Player
    {
        public Opponent(GameBoard board) : base(board)
        {

        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
