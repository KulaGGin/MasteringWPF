using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using Kulagin.Mastering_WPF.DataModels.Enums;


namespace Kulagin.Mastering_WPF.Converters {

    [ValueConversion(typeof(FeedbackType), typeof(ImageSource))]
    public class FeedbackTypeToImageSourceConverter : IValueConverter {
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {

            if(!(value is FeedbackType feedbackType) || targetType != typeof(ImageSource)) return DependencyProperty.UnsetValue;
            string imageName = string.Empty;

            switch(feedbackType) {
            case FeedbackType.None: return DependencyProperty.UnsetValue;
            case FeedbackType.Error: imageName = "Error_16"; break;
            case FeedbackType.Success: imageName = "Success_16"; break;
            case FeedbackType.Validation:
            case FeedbackType.Warning: imageName = "Warning_16"; break;
            case FeedbackType.Information: imageName = "Information_16"; break;
            case FeedbackType.Question: imageName = "Question_16"; break;
            default: return DependencyProperty.UnsetValue;
            }

            return $"pack://application:,,,/CompanyName.ApplicationName;component/Images/{ imageName }.png";
        }

        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return DependencyProperty.UnsetValue;
        }
    }
}
