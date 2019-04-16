using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Pacman.Models
{
    public class Box : ObservableObject
    {
        public int ID { get; }

        private BoxStatus _status;
        /// <summary>
        /// status of the box
        /// </summary>
        public BoxStatus Status
        {
            get { return _status; }
            set
            {
                _status = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(Background));
            }
        }

        /// <summary>
        /// old status of the box (used after player leaves the box -> set former value 
        /// </summary>
        public BoxStatus OldStatus { get; set; }

        /// <summary>
        /// background of the box
        /// </summary>
        public Brush Background
        {
            get
            {
                Brush brush;
                switch (Status)
                {
                    case BoxStatus.Wall:
                        brush = Brushes.Black;
                        break;
                    case BoxStatus.Free:
                        brush = Brushes.White;
                        break;
                    case BoxStatus.Pacman:
                        brush = Brushes.Red;
                        break;
                    case BoxStatus.Opponent:
                        brush = Brushes.Blue;
                        break;
                    case BoxStatus.Food:
                        brush = Brushes.Yellow;
                        break;
                    default:
                        brush = Brushes.White;
                        break;
                }
                return brush;
            }
        }

        public Box(int id, BoxStatus status)
        {
            ID = id;
            Status = status;
            OldStatus = BoxStatus.Food;
        }
    }
}
