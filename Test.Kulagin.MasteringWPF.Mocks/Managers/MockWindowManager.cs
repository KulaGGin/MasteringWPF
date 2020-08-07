using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.DataModels.Enums;
using Kulagin.MasteringWPF.Managers.Interfaces;


namespace Test.Kulagin.MasteringWPF.Mocks.Managers {
    public class MockWindowManager : IWindowManager {
        public MessageBoxButtonSelection ShowMessageBox(string message, string title, MessageBoxButton buttons, MessageBoxIcon icon) {
            switch(buttons) {
                case MessageBoxButton.Ok:
                case MessageBoxButton.OkCancel:
                    return MessageBoxButtonSelection.Ok;
                case MessageBoxButton.YesNo:
                case MessageBoxButton.YesNoCancel:
                    return MessageBoxButtonSelection.Yes;
                default: return MessageBoxButtonSelection.Ok;
            }
        }
    }
}
