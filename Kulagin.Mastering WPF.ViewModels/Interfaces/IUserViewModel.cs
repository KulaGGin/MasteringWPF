using System.Windows.Input;
using Kulagin.Mastering_WPF.DataModels;


namespace Kulagin.Mastering_WPF.ViewModels.Interfaces {
    public interface IUserViewModel {
        User User { get; set; }

        ICommand SaveCommand { get; }
    }
}