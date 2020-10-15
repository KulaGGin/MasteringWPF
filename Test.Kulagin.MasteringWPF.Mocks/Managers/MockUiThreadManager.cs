using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.Managers.Interfaces;


namespace Test.Kulagin.MasteringWPF.Mocks.Managers {
    public class MockUiThreadManager : IUiThreadManager {
        public object RunOnUiThread(Delegate method) {
            return method.DynamicInvoke();
        }

        public Task RunAsynchronously(Action method) {
            Task task = new Task(method);
            task.RunSynchronously();
            return task;
        }

        public Task<TResult> RunAsynchronously<TResult>(Func<TResult> method) {
            Task<TResult> task = new Task<TResult>(method);
            task.RunSynchronously();
            return task;
        }
    }
}