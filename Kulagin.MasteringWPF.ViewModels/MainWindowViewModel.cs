﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.DataModels;
using Kulagin.MasteringWPF.DataModels.Enums;


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
        }
    }
}