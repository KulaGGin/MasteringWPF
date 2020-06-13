using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Kulagin.Mastering_WPF.Managers;


namespace Kulagin.Mastering_WPF.Views.ViewModelLocators {
    public abstract class BaseViewModelLocator<T> : DependencyObject
        where T : class {
        private T runtimeViewModel, designTimeViewModel;

        protected bool IsDesignTime { get { return DesignerProperties.GetIsInDesignMode(this); } }
        public T ViewModel { get { return IsDesignTime ? DesignTimeViewModel : RuntimeViewModel; } }

        protected T RuntimeViewModel {
            get {
                return runtimeViewModel ?? (runtimeViewModel = DependencyManager.Instance.Resolve<T>());
            }
        }

        protected T DesignTimeViewModel { set { designTimeViewModel = value; } get { return designTimeViewModel; } }
    }
}
