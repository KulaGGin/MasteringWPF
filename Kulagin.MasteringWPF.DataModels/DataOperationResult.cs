using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.DataModels.Enums;
using Kulagin.MasteringWPF.Extensions;


namespace Kulagin.MasteringWPF.DataModels {
    public abstract class DataOperationResult<T> {
        public DataOperationResult(string successText) {
            Description = string.IsNullOrEmpty(successText) ? "The data operation was successful" : successText;
        }

        public DataOperationResult(Exception exception, string errorText) {
            Exception = exception;

            if (Exception is SqlException) {
                if (exception.Message.Contains("The server was not found"))
                    Error = DataOperationError.DatabaseConnectionError;
                else if (exception.Message.Contains("constraint"))
                    Error = DataOperationError.DatabaseConstraintError;

                // else Description = Exception.Message;
            }

            if (Error != DataOperationError.None)
                Description = Error.GetDescription();
            else {
                Error = DataOperationError.UndeterminedDataOperationError;
                Description = string.IsNullOrEmpty(errorText) ? Error.GetDescription() : errorText;
            }
        }

        public DataOperationResult(Exception exception) : this(exception, string.Empty) {
        }

        public string Description { get; set; }

        public DataOperationError Error { get; set; } = DataOperationError.None;

        public Exception Exception { get; set; } = null;

        public bool IsSuccess {
            get { return Error == DataOperationError.None && Exception == null; }
        }
    }
}