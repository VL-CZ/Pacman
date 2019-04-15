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
        /// background of the box
        /// </summary>
        public Color Background
        {
            get
            {
                Color color;
                switch (Status)
                {
                    case BoxStatus.Wall:
                        color = Colors.Black;
                        break;
                    case BoxStatus.Free:
                        color = Colors.White;
                        break;
                    case BoxStatus.Pacman:
                        color = Colors.Red;
                        break;
                    case BoxStatus.Opponent:
                        color = Colors.Blue;
                        break;
                    case BoxStatus.Food:
                        color = Colors.LightYellow;
                        break;
                    default:
                        color = Colors.White;
                        break;
                }
                return color;
            }
        }

        public Box(int id, BoxStatus status)
        {
            ID = id;
            Status = status;
        }
    }
}
