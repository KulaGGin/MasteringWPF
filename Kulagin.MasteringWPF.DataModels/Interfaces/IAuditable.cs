using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulagin.MasteringWPF.DataModels.Interfaces {
    public interface IAuditable {
        DateTime CreatedOn { get; set; }
        User CreatedBy { get; set; }
        DateTime? UpdatedOn { get; set; }
        User UpdatedBy { get; set; }
    }
}
