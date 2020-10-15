using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulagin.MasteringWPF.DataModels {
    public class GetDataOperationResult<T> : DataOperationResult<T> {
        public GetDataOperationResult(Exception exception, string errorText) :
            base(exception, errorText) {
            ReturnValue = default(T);
        }

        public GetDataOperationResult(Exception exception) :
            this(exception, string.Empty) {

        }
        public GetDataOperationResult(T returnValue, string successText) :
            base(successText) {
            ReturnValue = returnValue;
        }

        public GetDataOperationResult(T returnValue) :
            this(returnValue, string.Empty) {

        }

        public T ReturnValue { get; private set; }
    }
}
