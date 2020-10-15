using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulagin.MasteringWPF.DataModels {
    public class SetDataOperationResult : DataOperationResult<bool> {

        public SetDataOperationResult(Exception exception, string errorText) :
            base(exception, errorText) {

        }

        public SetDataOperationResult(string successText) :
            base(successText) {

        }
    }
}
