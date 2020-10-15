using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Kulagin.MasteringWPF.DataModels;
using Kulagin.MasteringWPF.DataModels.Collections;
using Kulagin.MasteringWPF.Extensions;


namespace Kulagin.MasteringWPF.Views.Controls {
    /// <summary>
    /// Interaction logic for FeedbackControl.xaml
    /// </summary>
    public partial class FeedbackControl : UserControl {
        private static List<DispatcherTimer> timers = new List<DispatcherTimer>();

        public FeedbackControl() {
            InitializeComponent();
        }

        public static readonly DependencyProperty FeedbackProperty =
            DependencyProperty.Register(
                                 nameof(Feedback),
                                 typeof(FeedbackCollection),
                                 typeof(FeedbackControl),
                                 new UIPropertyMetadata(
                                       new FeedbackCollection(),
                                       FeedbackPropertyChangedCallback)
                                 );

        private static void FeedbackPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs eventArgs) {
            FeedbackCollection feedBcCollection = (FeedbackCollection)eventArgs.NewValue;
            FeedbackControl feedbackControl = (FeedbackControl)dependencyObject;

            feedBcCollection.CollectionChanged += feedbackControl.Feedback_CollectionChanged;
        }

        public FeedbackCollection Feedback { get { return (FeedbackCollection)GetValue(FeedbackProperty); } set { SetValue(FeedbackProperty, value); } }

        public static readonly DependencyProperty HasFeedbackProperty =
            DependencyProperty.Register(nameof(HasFeedback),
                                        typeof(bool),
                                        typeof(FeedbackControl),
                                        new PropertyMetadata(true));

        public bool HasFeedback {
            get {
                bool hasFeedback = (bool)GetValue(HasFeedbackProperty);
                return hasFeedback;
            }
            set {
                SetValue(HasFeedbackProperty, value);
            }
        }

        private void Feedback_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            if ((e.OldItems == null || e.OldItems.Count == 0) && e.NewItems != null && e.NewItems.Count > 0) {
                e.NewItems.OfType<Feedback>().Where(f => !f.IsPermanent).ForEach(f => InitializeTimer(f));
            }

            HasFeedback = Feedback.Any();
        }

        private void InitializeTimer(Feedback feedback) {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = feedback.Duration;
            timer.Tick += Timer_Tick;
            timer.Tag = new Tuple<Feedback, DateTime>(feedback, DateTime.Now);
            timer.Start();
            timers.Add(timer);
        }

        private void Timer_Tick(object sender, EventArgs e) {
            DispatcherTimer timer = (DispatcherTimer)sender;
            timer.Stop();
            timer.Tick -= Timer_Tick;
            timers.Remove(timer);
            Feedback feedback = ((Tuple<Feedback, DateTime>)timer.Tag).Item1;
            Feedback.Remove(feedback);
        }

        private void DeleteButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            Button deleteButton = (Button)sender;
            Feedback feedback = (Feedback)deleteButton.DataContext;
            Feedback.Remove(feedback);
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e) {
            foreach (DispatcherTimer timer in timers) {
                timer.Stop();
                Tuple<Feedback, DateTime> tag = (Tuple<Feedback, DateTime>)timer.Tag;

                tag.Item1.Duration = timer.Interval = tag.Item1.Duration.Subtract(DateTime.Now.Subtract(tag.Item2));
            }
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e) {
            foreach (DispatcherTimer timer in timers) {
                Feedback feedback = ((Tuple<Feedback, DateTime>)timer.Tag).Item1;
                timer.Tag = new Tuple<Feedback, DateTime>(feedback, DateTime.Now);
                timer.Start();
            }
        }
    }
}