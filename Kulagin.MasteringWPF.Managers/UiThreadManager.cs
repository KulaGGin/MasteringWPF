using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Kulagin.MasteringWPF.Managers.Interfaces;

namespace Kulagin.MasteringWPF.Managers {
    public class UiThreadManager : IUiThreadManager {
        public object RunOnUiThread(Delegate method) {
            return Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, method);
        }
        public Task RunAsynchronously(Action method) {
            return Task.Run(method);
        }
        public Task<TResult> RunAsynchronously<TResult>(Func<TResult> method) {
            return Task.Run(method);
        }
    }
}
