using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasketUnit.WebAPI.Models
{
    public interface IAuditEntity
    {
        int? CreatedById { get; set; }
        DateTime CreatedDate { get; set; }
        int? ModifiedById { get; set; }
        DateTime? ModifiedDate { get; set; }
    }
}
