using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aea.Shared
{
    public abstract class AuditableEntity<T>: Entity<T>, IAuditableEntity
    {
        [ScaffoldColumn(false)]
        [MaxLength(256)]
        public string CreatedBy { get; set; }
        [ScaffoldColumn(false)]
        public DateTime CreatedTime { get; set; }
        [ScaffoldColumn(false)]
        [MaxLength(256)]
        public string ModifiedBy { get; set; }
        [ScaffoldColumn(false)]
        public DateTime ModifiedTime { get; set; }
        [ScaffoldColumn(false)]
        public T Id { get; set; }
    }
}
