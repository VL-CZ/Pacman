﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Models
{
    public abstract class Player : ObservableObject
    {
        protected GameBoard _board;
        /// <summary>
        /// is player alive?
        /// </summary>
        public bool Alive { get; protected set; }

        /// <summary>
        /// position in the map
        /// </summary>
        public Point Position { get; protected set; }

        public Player(GameBoard board, Point position)
        {
            _board = board;
            Alive = true;
            Position = position;
            SetBoardToNewPosition(position);
        }

        public abstract void Move();

        /// <summary>
        /// change position in the board to <paramref name="newPosition"/> 
        /// </summary>
        /// <param name="newPosition"></param>
        public void SetBoardToNewPosition(Point newPosition)
        {
            if (!_board.IsFree(newPosition)) // wall -> return
            {
                return;
            }
            _board[Position].Status = BoxStatus.Free; // unset old position
            Position = newPosition; // refresh position

            if (this is Pacman) // set new position in the board
            {
                ((Pacman)this).CheckDeath();
                ((Pacman)this).CheckScore();
                _board[Position].Status = BoxStatus.Pacman;
            }
            else if (this is Opponent)
            {
                _board[Position].Status = BoxStatus.Opponent;
            }
        }
    }
}
