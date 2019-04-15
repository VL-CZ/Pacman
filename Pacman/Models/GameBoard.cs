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
        public ObservableCollection<ObservableCollection<Box>> Board { get; }

        public int Size { get; }

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
                Initialize();
            }
        }

        /// <summary>
        /// initialize board with boxes
        /// </summary>
        private void Initialize()
        {
            for (int i = 0; i < Size; i++)
            {
                var row = new ObservableCollection<Box>();
                for (int j = 0; j < Size; j++)
                {
                    int cellID = i * Size + j;
                    row.Add(new Box(cellID, 0));
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
    }
}
