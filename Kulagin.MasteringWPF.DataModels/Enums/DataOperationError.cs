using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulagin.MasteringWPF.DataModels.Enums {
    public enum DataOperationError {
        [Description("")]
        None = 0,
        [Description("A database constraint has not been adhered to, so this operation cannot be completed")]
        DatabaseConstraintError = 9995,
        [Description("There was an undetermined data operation error")]
        UndeterminedDataOperationError = 9997,
        [Description("There was a problem connecting to the database")]
        DatabaseConnectionError = 9998,
    }
}
