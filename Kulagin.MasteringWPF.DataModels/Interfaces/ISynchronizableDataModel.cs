using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulagin.MasteringWPF.DataModels.Interfaces {
    public interface ISynchronizableDataModel<T> where T: class, new() {

        /// <summary>
        /// Gets a value that specifies whether any properties in any object in the collection have changed since they were last synchronized or not.
        /// </summary>
        bool HasChanges { get; }

        /// <summary>
        /// Gets a value that specifies whether the object has been synchronized or not.
        /// </summary>
        bool IsSynchronized { get; }

        /// <summary>
        /// Reverts the values of all of the properties in this object to the state that they were in when they were last synchronized.
        /// </summary>
        void RevertState();

        /// <summary>
        /// Synchronizes the value of the internal synchronization member with the current property values of this object.
        /// </summary>
        void Synchronize();

        /// <summary>
        /// Copies all of the values from the dataModel input parameter to this object.
        /// </summary>
        /// <param name="dataModel">The object to copy the values from.</param>
        void CopyValuesFrom(T dataModel);
    }
}
