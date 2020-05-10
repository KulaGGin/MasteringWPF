using Kulagin.Mastering_WPF.Managers;
using Kulagin.Mastering_WPF.ViewModels.Interfaces;


namespace Kulagin.Mastering_WPF.Views.ViewModelLocators {
    public class ViewModelLocator {
        public IUserViewModel UserViewModel { get { return DependencyManager.Instance.Resolve<IUserViewModel>(); } }
    }
}