﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Kulagin.MasteringWPF.ViewModels.Commands {
    public class ActionCommand : ICommand {

        private EventHandler eventHandler;
        private readonly Action<object> action;
        private readonly Predicate<object> canExecute;

        public ActionCommand(Action<object> action) : this(action, null) {
        }

        public ActionCommand(Action<object> action, Predicate<object> canExecute) {
            this.action = action;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged {
            add {
                eventHandler += value;
                CommandManager.RequerySuggested += value;
            }
            remove {
                eventHandler -= value;
                CommandManager.RequerySuggested -= value;
            }
        }

        public void RaiseCanExecuteChanged() {
            eventHandler?.Invoke(this, new EventArgs());
        }

        public bool CanExecute(object parameter) {
            return canExecute == null ? true : canExecute(parameter);
        }

        public void Execute(object parameter) {
            action(parameter);
        }
    }
}
