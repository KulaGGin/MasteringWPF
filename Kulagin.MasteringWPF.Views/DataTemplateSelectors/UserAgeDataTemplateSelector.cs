using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Kulagin.MasteringWPF.DataModels;


namespace Kulagin.MasteringWPF.Views.DataTemplateSelectors {
    public class UserAgeDataTemplateSelector : DataTemplateSelector {
        public override DataTemplate SelectTemplate(object item, DependencyObject container) {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is User user) {
                if (user.Age < 35) return (DataTemplate)element.FindResource("InverseUserTemplate");
                else return (DataTemplate)element.FindResource("UserTemplate");
            }

            return null;
        }
    }
}