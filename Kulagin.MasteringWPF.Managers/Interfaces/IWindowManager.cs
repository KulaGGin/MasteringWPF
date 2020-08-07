using Kulagin.MasteringWPF.DataModels.Enums;

namespace Kulagin.MasteringWPF.Managers.Interfaces {
    public interface IWindowManager {
        MessageBoxButtonSelection ShowMessageBox(string message, string title, MessageBoxButton buttons, MessageBoxIcon icon);
    }
}
