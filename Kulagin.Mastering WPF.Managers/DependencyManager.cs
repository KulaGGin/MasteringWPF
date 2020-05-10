using System;
using System.Collections.Generic;


namespace Kulagin.Mastering_WPF.Managers {
    public class DependencyManager {

        private static DependencyManager instance;

        private static Dictionary<Type, Type> registeredDependencies =
            new Dictionary<Type, Type>();


        private DependencyManager() {
        }


        public static DependencyManager Instance { get { return instance ?? (instance = new DependencyManager()); } }

        public int Count { get { return registeredDependencies.Count; } }


        public void ClearRegistrations() {
            registeredDependencies.Clear();
        }


        public void Register<S, T>() where S : class where T : class {
            if (!typeof(S).IsInterface) throw new ArgumentException("The Sgeneric type parameter of the Register method must be an interface.", "S");
            if (!typeof(S).IsAssignableFrom(typeof(T)))
                throw
                    new ArgumentException("The T generic type parameter must be a class that implements the interface specified by the S generic type parameter.", "T");

            if (!registeredDependencies.ContainsKey(typeof(S)))
                registeredDependencies.Add(typeof(S), typeof(T));
        }


        public T Resolve<T>() where T : class {
            Type type = registeredDependencies[typeof(T)];

            return Activator.CreateInstance(type) as T;
        }


        public T Resolve<T>(params object[] args) where T : class {
            Type type = registeredDependencies[typeof(T)];

            if (args == null || args.Length == 0)
                return Activator.CreateInstance(type) as T;
            else return Activator.CreateInstance(type, args) as T;
        }
    }
}