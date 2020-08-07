using System.Windows;
using Kulagin.MasteringWPF.Managers.Interfaces;
using MessageBoxButton = Kulagin.MasteringWPF.DataModels.Enums.MessageBoxButton;
using MessageBoxButtonSelection = Kulagin.MasteringWPF.DataModels.Enums.MessageBoxButtonSelection;
using MessageBoxIcon = Kulagin.MasteringWPF.DataModels.Enums.MessageBoxIcon;
using System.Windows;
using Kulagin.MasteringWPF.DataModels.Enums;
using Kulagin.MasteringWPF.Managers.Interfaces;


namespace Kulagin.MasteringWPF.Managers {
    public class WindowManager : IWindowManager {
        public MessageBoxButtonSelection ShowMessageBox(string message, string title, MessageBoxButton buttons, MessageBoxIcon icon) {
            System.Windows.MessageBoxButton messageBoxButtons;
            switch(buttons) {
                case MessageBoxButton.Ok:
                    messageBoxButtons = System.Windows.MessageBoxButton.OK; break;
                case MessageBoxButton.OkCancel:
                    messageBoxButtons = System.Windows.MessageBoxButton.OKCancel; break;
                case MessageBoxButton.YesNo:
                    messageBoxButtons = System.Windows.MessageBoxButton.YesNo; break;
                case MessageBoxButton.YesNoCancel:
                    messageBoxButtons = System.Windows.MessageBoxButton.YesNoCancel; break;
                default:
                    messageBoxButtons = System.Windows.MessageBoxButton.OKCancel; break;
            }
            
            MessageBoxImage messageBoxImage;
            switch(icon) {
                case MessageBoxIcon.Asterisk:
                    messageBoxImage = MessageBoxImage.Asterisk; break;
                case MessageBoxIcon.Error:
                    messageBoxImage = MessageBoxImage.Error; break;
                case MessageBoxIcon.Exclamation:
                    messageBoxImage = MessageBoxImage.Exclamation; break;
                case MessageBoxIcon.Hand:
                    messageBoxImage = MessageBoxImage.Hand; break;
                case MessageBoxIcon.Information:
                    messageBoxImage = MessageBoxImage.Information; break;
                case MessageBoxIcon.None:
                    messageBoxImage = MessageBoxImage.None; break;
                case MessageBoxIcon.Question:
                    messageBoxImage = MessageBoxImage.Question; break;
                case MessageBoxIcon.Stop:
                    messageBoxImage = MessageBoxImage.Stop; break;
                case MessageBoxIcon.Warning:
                    messageBoxImage = MessageBoxImage.Warning; break;
                default: messageBoxImage = MessageBoxImage.Stop; break;
            }

            MessageBoxButtonSelection messageBoxButtonSelection = MessageBoxButtonSelection.None;
            switch(MessageBox.Show(message, title, messageBoxButtons, messageBoxImage)) {
                case MessageBoxResult.Cancel:
                    messageBoxButtonSelection = MessageBoxButtonSelection.Cancel; break;
                case MessageBoxResult.No:
                    messageBoxButtonSelection = MessageBoxButtonSelection.No; break;
                case MessageBoxResult.OK:
                    messageBoxButtonSelection = MessageBoxButtonSelection.Ok; break;
                case MessageBoxResult.Yes:
                    messageBoxButtonSelection = MessageBoxButtonSelection.Yes; break;
            }
            return messageBoxButtonSelection;
        }
    }
}
