using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kulagin.MasteringWPF.DataModels {
    public class Cell : BaseDataModel {
        private string address = string.Empty;
        private string content = string.Empty;
        private double width = 0;

        public Cell(string address, string content, double width) {
            Address = address;
            Content = content;
            Width = width;
        }

        public string Address {
            get { return address; }
            set {
                if (address != value) {
                    address = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Content {
            get { return content; }
            set {
                if (content != value) {
                    content = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public double Width {
            get { return width; }
            set {
                if (width != value) {
                    width = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public override string ToString() {
            return $"{Address}: {Content}";
        }
    }
}