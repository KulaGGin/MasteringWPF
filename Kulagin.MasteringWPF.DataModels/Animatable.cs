using System;
using Kulagin.MasteringWPF.DataModels.Enums;
using Kulagin.MasteringWPF.DataModels.Interfaces;


namespace Kulagin.MasteringWPF.DataModels {
    public class Animatable {
        private AdditionStatus additionStatus = AdditionStatus.ReadyToAnimate;
        private RemovalStatus removalStatus = RemovalStatus.None;
        private TransitionStatus transitionStatus = TransitionStatus.None;
        private IAnimatable owner;

        public Animatable(IAnimatable owner) {
            Owner = owner;
        }

        public Animatable() {
        }

        public event EventHandler<EventArgs> OnRemovalStatusChanged;
        public event EventHandler<EventArgs> OnTransitionStatusChanged;
        public IAnimatable Owner { get { return owner; } set { owner = value; } }
        public AdditionStatus AdditionStatus { get { return additionStatus; } set { additionStatus = value; } }

        public TransitionStatus TransitionStatus {
            get { return transitionStatus; }
            set {
                transitionStatus = value;
                OnTransitionStatusChanged?.Invoke(this, new EventArgs());
            }
        }

        public RemovalStatus RemovalStatus {
            get { return removalStatus; }
            set {
                removalStatus = value;
                OnRemovalStatusChanged?.Invoke(this, new EventArgs());
            }
        }
    }
}