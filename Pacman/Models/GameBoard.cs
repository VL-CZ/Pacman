using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Models
{
    public class GameBoard : ObservableObject
    {
        private Random _generator;

        /// <summary>
        /// game board
        /// </summary>
        public ObservableCollection<ObservableCollection<Box>> Board { get; }

        /// <summary>
        /// height/width of the board (dimensions are the same)
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// number of boxes in the board
        /// </summary>
        public int BoxCount
        {
            get
            {
                return Size * Size;
            }
        }

        /// <summary>
        /// N x N gameboard
        /// </summary>
        /// <param name="N"></param>
        public GameBoard(int N)
        {
            if (N % 2 == 0)
            {
                throw new ArgumentException();
            }
            else
            {
                Board = new ObservableCollection<ObservableCollection<Box>>();
                Size = N;
                _generator = new Random();
                Initialize();
            }
        }

        /// <summary>
        /// get/set specified box in the board
        /// </summary>
        /// <param name="coord1"></param>
        /// <param name="coord2"></param>
        /// <returns></returns>
        public Box this[int coord1, int coord2]
        {
            get
            {
                return Board[coord1][coord2];
            }
            set
            {
                Board[coord1][coord2] = value;
            }
        }

        /// <summary>
        /// get/set specified box in the board
        /// </summary>
        /// <param name="position">position of the box</param>
        /// <returns></returns>
        public Box this[Point position]
        {
            get
            {
                return this[position.Coord1, position.Coord2];
            }
            set
            {
                this[position.Coord1, position.Coord2] = value;
            }
        }

        /// <summary>
        /// initialize board
        /// </summary>
        private void Initialize()
        {
            for (int i = 0; i < Size; i++)
            {
                var row = new ObservableCollection<Box>();
                for (int j = 0; j < Size; j++)
                {
                    int cellID = i * Size + j;
                    BoxStatus status = BoxStatus.Food;

                    if (i == 0 || j == 0 || (i == Size - 1) || (j == Size - 1)) // border of the labyrinth
                    {
                        status = BoxStatus.Wall;
                    }
                    else if ((i % 2 == 0 && j % 2 == 0) || (_generator.Next(1, 10) < 3 && (i + j) % 2 == 1)) // labyrinth generator
                    {
                        status = BoxStatus.Wall;
                    }
                    row.Add(new Box(cellID, status));
                }
                Board.Add(row);
            }
        }

        /// <summary>
        /// get box from the board by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Box GetBoxByID(int id)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Box box = Board[i][j];
                    if (box.ID == id)
                    {
                        return box;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// checks if this position is free (not a wall)
        /// </summary>
        /// <param name="box"></param>
        /// <returns></returns>
        public bool IsFree(Box box)
        {
            return box.Status != BoxStatus.Wall;
        }

        /// <summary>
        /// checks if this position is free (not a wall)
        /// </summary>
        public bool IsFree(Point position)
        {
            return IsFree(this[position.Coord1, position.Coord2]);
        }
    }
}
