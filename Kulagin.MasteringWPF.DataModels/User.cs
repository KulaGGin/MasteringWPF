using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kulagin.MasteringWPF.DataModels.Interfaces;


namespace Kulagin.MasteringWPF.DataModels {
    public class User : IAuditable {
        private Auditable auditable;

        public Auditable Auditable {
            get { return auditable; }
            set { auditable = value; }
        }
    }
}
