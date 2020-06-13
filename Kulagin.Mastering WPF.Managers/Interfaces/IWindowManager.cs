using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulagin.Mastering_WPF.DataModels.Enums;


namespace Kulagin.Mastering_WPF.Managers.Interfaces {
    public interface IWindowManager {
        MessageBoxButtonSelection ShowMessageBox(string message,
                                                 string title, MessageBoxButton buttons, MessageBoxIcon icon);
    }
}
