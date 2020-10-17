using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.DataModels;
using Kulagin.MasteringWPF.DataModels.Enums;
using Kulagin.MasteringWPF.Managers;
using Kulagin.MasteringWPF.ViewModels.Properties;


namespace Kulagin.MasteringWPF.ViewModels {
    public class MainWindowViewModel : BaseViewModel {
        private BaseViewModel viewModel;
        private PageModel activePage = null;
        private ObservableCollection<PageModel> pages = null;

        /// <summary>
        /// Initializes a new MainWindowViewModel with default values.
        /// </summary>
        public MainWindowViewModel() {
            InitializeData();
            activePage = pages[0];
        }

        /// <summary>
        /// Gets or sets the BaseViewModel object that is currently displayed in the application.
        /// </summary>
        public BaseViewModel ViewModel {
            get { return viewModel; }
            set { if(viewModel != value) { viewModel = value; NotifyPropertyChanged(); } }
        }

        /// <summary>
        /// Gets or sets the collection of PageModel objects that relate to views to display in the application.
        /// </summary>
        public ObservableCollection<PageModel> Pages {
            get { return pages; }
            set { if(pages != value) { pages = value; NotifyPropertyChanged(); } }
        }

        /// <summary>
        /// Gets or sets the selected PageModel instance from the collection of PageModel objects that relate to views to display in the application.
        /// </summary>
        public PageModel ActivePage {
            get { return activePage; }
            set {
                if(activePage != value) {
                    activePage = value;
                    NotifyPropertyChanged();

                    if(activePage != null) ViewModel = Activator.CreateInstance(activePage.Type) as BaseViewModel;
                }
            }
        }

        private void InitializeData() {
            pages = new ObservableCollection<PageModel>();
            pages.Add(new PageModel(typeof(BitRateViewModel), Page.BitRate, Chapter.Four));
            pages.Add(new PageModel(typeof(WeightMeasurementsViewModel), Page.WeightMeasurements, Chapter.Four));
            pages.Add(new PageModel(typeof(AllUsersViewModel), Page.User, Chapter.Four));
            pages.Add(new PageModel(typeof(RightControlsViewModel), Page.RightControls, Chapter.Five));
            pages.Add(new PageModel(typeof(BuiltInControlsViewModel), Page.BuiltInControls, Chapter.Six));
            pages.Add(new PageModel(typeof(AnimationViewModel), Page.Animation, Chapter.Seven));
            pages.Add(new PageModel(typeof(EasingAnimationViewModel), Page.EasingAnimation, Chapter.Eight));
            pages.Add(new PageModel(typeof(ButtonViewModel), Page.Button, Chapter.Eight));
            pages.Add(new PageModel(typeof(VisuallyAppealingViewModel), Page.VisuallyAppealing, Chapter.Eight));
            pages.Add(new PageModel(typeof(AllProductsViewModel), Page.Validation, Chapter.Nine));
            pages.Add(new PageModel(typeof(DrawingViewModel), Page.Drawing, Chapter.Eleven));
        }

        public void LoadSettings() {
            Settings.Default.Reload();
            StateManager.AreAuditFieldsVisible = Settings.Default.AreAuditFieldsVisible;
            StateManager.AreSearchTermsSaved = Settings.Default.AreSearchTermsSaved;
        }
        public void SaveSettings() {
            Settings.Default.AreAuditFieldsVisible = StateManager.AreAuditFieldsVisible;
            Settings.Default.AreSearchTermsSaved = StateManager.AreSearchTermsSaved;
            Settings.Default.Save();
        }
    }
}
