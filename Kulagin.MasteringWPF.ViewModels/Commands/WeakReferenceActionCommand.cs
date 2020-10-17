using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Kulagin.MasteringWPF.ViewModels.Commands {
    public class WeakReferenceActionCommand : ICommand {
        private readonly Action<object> action;
        private readonly Predicate<object> canExecute;
        private List<WeakReference> eventHandlers = new List<WeakReference>();

        public WeakReferenceActionCommand(Action<object> action) :
            this(action, null) {
        }

        public WeakReferenceActionCommand(Action<object> action, Predicate<object> canExecute) {
            if (action == null)
                throw new ArgumentNullException("The action input parameter of the WeakReferenceActionCommand constructor cannot be null.");

            this.action = action;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged {
            add {
                eventHandlers.Add(new WeakReference(value));
                CommandManager.RequerySuggested += value;
            }
            remove {
                if (eventHandlers == null) return;

                for (int i = eventHandlers.Count - 1; i >= 0; i--) {
                    WeakReference weakReference = eventHandlers[i];
                    EventHandler handler = weakReference.Target as EventHandler;

                    if (handler == null || handler == value) {
                        eventHandlers.RemoveAt(i);
                    }
                }

                CommandManager.RequerySuggested -= value;
            }
        }

        public void RaiseCanExecuteChanged() {
            eventHandlers.ForEach(r => (r.Target as EventHandler)?.Invoke(this, new EventArgs()));
        }

        public bool CanExecute(object parameter) {
            return canExecute == null ? true : canExecute(parameter);
        }

        public void Execute(object parameter) {
            action(parameter);
        }
    }
}