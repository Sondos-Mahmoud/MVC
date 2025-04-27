using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }//userid
        public DateTime? CreatedOn { get; set; }//time of create
        public int LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }//time of create

        public bool IsDeleted { get; set; }//soft delete
    }
}
