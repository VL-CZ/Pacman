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
                RaisePropertyChanged(nameof(BackgroundPath));
            }
        }

        /// <summary>
        /// old status of the box (used after player leaves the box -> set former value 
        /// </summary>
        public BoxStatus OldStatus { get; set; }

        /// <summary>
        /// path to background image of the box
        /// </summary>
        public string BackgroundPath
        {
            get
            {
                string path;
                switch (Status)
                {
                    case BoxStatus.Wall:
                        path = @"~\..\Images\Wall.png";
                        break;
                    case BoxStatus.Free:
                        path = @"~\..\Images\Free.png";
                        break;
                    case BoxStatus.Pacman:
                        path = @"~\..\Images\Pacman.png";
                        break;
                    case BoxStatus.Opponent:
                        path = @"~\..\Images\Opponent.png";
                        break;
                    case BoxStatus.Food:
                        path = @"~\..\Images\Food.png";
                        break;
                    default:
                        path = @"~\..\Images\Free.png";
                        break;
                }
                return path;
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
