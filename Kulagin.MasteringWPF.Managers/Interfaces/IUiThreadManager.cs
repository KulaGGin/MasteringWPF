using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulagin.MasteringWPF.Managers.Interfaces {
    public interface IUiThreadManager {
        object RunOnUiThread(Delegate method);
        Task RunAsynchronously(Action method);
        Task<TResult> RunAsynchronously<TResult>(Func<TResult> method);
    }
}
