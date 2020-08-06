using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.DataModels.Interfaces;


namespace Kulagin.MasteringWPF.DataModels {
    public class Invoice : BaseDataModel, IAuditable {
        #region Implementation of IAuditable

        public Auditable Auditable { get; set; }

        #endregion

    }
}
